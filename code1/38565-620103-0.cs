    string postData = "userid=ducon";
                postData += "&username=camarche" ;
                byte[] data = Encoding.ASCII.GetBytes(postData);
                WebRequest req = WebRequest.Create(
                    URL);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = data.Length;
                Stream newStream = req.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream(), System.Text.Encoding.GetEncoding("iso-8859-1"));
                string coco = reader.ReadToEnd();
