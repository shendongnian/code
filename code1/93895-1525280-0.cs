			string post_data = "username=" + HttpUtility.UrlEncode(ServiceUsername)
				+ "&password=" + HttpUtility.UrlEncode(ServicePassword)
				+ "&projectid=" + Convert.ToString(projectid)
				+ "&from=" + HttpUtility.UrlEncode(from)
				+ "&short_desc=" + HttpUtility.UrlEncode(subject)
				+ "&message=" + HttpUtility.UrlEncode(message);
			byte[] bytes = Encoding.UTF8.GetBytes(post_data);
			// send request to web server
			HttpWebResponse res = null;
			try
			{
				HttpWebRequest req = (HttpWebRequest) System.Net.WebRequest.Create(Url);
				req.Credentials = CredentialCache.DefaultCredentials;
				req.PreAuthenticate = true; 
				//req.Timeout = 200; // maybe?
				//req.KeepAlive = false; // maybe?
			
				req.Method = "POST";
				req.ContentType= "application/x-www-form-urlencoded";
				req.ContentLength=bytes.Length;
				Stream request_stream = req.GetRequestStream();
				request_stream.Write(bytes,0,bytes.Length);
				request_stream.Close();
				res = (HttpWebResponse) req.GetResponse();
			}
			catch (Exception e)
			{
				write_line("HttpWebRequest error url=" + Url);
				write_line(e);
			}
			// examine response
			if (res != null) {
				int http_status = (int) res.StatusCode;
				write_line (Convert.ToString(http_status));
				string http_response_header = res.Headers["BTNET"];
				res.Close();
				if (http_response_header != null)
				{
					write_line (http_response_header);
					// only delete message from pop3 server if we
					// know we stored in on the web server ok
					if (MessageInputFile == ""
					&& http_status == 200
					&& DeleteMessagesOnServer == "1"
					&& http_response_header.IndexOf("OK") == 0)
					{
						write_line ("sending POP3 command DELE");
						write_line (client.DELE (message_number));
					}
				}
				else
				{
					write_line("BTNET HTTP header not found.  Skipping the delete of the email from the server.");
					write_line("Incrementing total error count");
					total_error_count++;
				}
			}
			else
			{
				write_line("No response from web server.  Skipping the delete of the email from the server.");
				write_line("Incrementing total error count");
				total_error_count++;
			}
