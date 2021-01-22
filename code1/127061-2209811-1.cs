 	   public void Dummy()
		{
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields.Add("key", "something");
			HttpWebRequest hr = WebRequest.Create("http://imgur.com/api/upload.xml") as HttpWebRequest;
			string bound = "----------------------------" + DateTime.Now.Ticks.ToString("x");
			hr.ContentType = "multipart/form-data; boundary=" + bound;
			hr.Method = "POST";
			hr.KeepAlive = true;
			hr.Credentials = CredentialCache.DefaultCredentials;
			byte[] boundBytes = Encoding.ASCII.GetBytes("\r\n--" + bound + "\r\n");
			string formDataTemplate = "\r\n--" + bound + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";
			//add fields + a boundary
			MemoryStream fieldData = new MemoryStream();
			foreach (string key in fields.Keys)
			{
				byte[] formItemBytes = Encoding.UTF8.GetBytes(
					string.Format(formDataTemplate, key, fields[key]));
				fieldData.Write(formItemBytes, 0, formItemBytes.Length);
			}
			fieldData.Write(boundBytes, 0, boundBytes.Length);
			//calculate the total length we expect to send
			List<string> files = new List<string> { Server.MapPath("/Images/Phillip.jpg") };
			string headerTemplate =
				"Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/octet-stream\r\n\r\n";
			long fileBytes = 0;
			foreach (string f in files)
			{
				byte[] headerBytes = Encoding.UTF8.GetBytes(
					String.Format(headerTemplate, "image", f));
				FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read);
				
				fileBytes += headerBytes.Length;
				fileBytes += fs.Length;
				fileBytes += boundBytes.Length;
				fs.Close();
			}
			hr.ContentLength = fieldData.Length + fileBytes;
			Stream s = hr.GetRequestStream();			
			//write the fields to the request stream
			Debug.WriteLine("sending field data");
			fieldData.WriteTo(s);
			//write the files to the request stream
			Debug.WriteLine("sending file data");
			foreach (string f in files)
			{
				byte[] headerBytes = Encoding.UTF8.GetBytes(
					String.Format(headerTemplate, "image", f));
				s.Write(headerBytes, 0, headerBytes.Length);
				FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read);
				int bytesRead = 0;
				long bytesSoFar = 0;
				byte[] buffer = new byte[10240];
				while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
				{
					bytesSoFar += bytesRead;
					s.Write(buffer, 0, bytesRead);
					Debug.WriteLine(String.Format("sending file data {0:0.000}%", (bytesSoFar * 100.0f) / fs.Length));
				}
				s.Write(boundBytes, 0, boundBytes.Length);
				fs.Close();
			}
			s.Close();
			GetResponseDel d = new GetResponseDel(GetResponse);
			ResponseData data = new ResponseData { del = d };
			d.BeginInvoke(hr, EndGetResponse, data);
			
			while (!hr.HaveResponse)
			{
				Debug.Write("waiting for response" + "\n");
				Thread.Sleep(150);
			}
			
			Debug.Write(data.responseString);
			hr = null;
		}
		delegate WebResponse GetResponseDel(HttpWebRequest hr);
		private WebResponse GetResponse(HttpWebRequest hr)
		{
			return hr.GetResponse();
		}
		class ResponseData
		{
			public GetResponseDel del { get; set; }
			public string responseString { get; set; }
		}
		private void EndGetResponse(IAsyncResult res)
		{
			ResponseData data = (ResponseData)res.AsyncState;
			GetResponseDel d = data.del;
			
			WebResponse r = d.EndInvoke(res);
			data.responseString = new StreamReader(r.GetResponseStream()).ReadToEnd();
		}
