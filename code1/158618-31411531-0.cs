    errorMessage = string.Empty;
            try
            {
                byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(xmlFileContent);
                webRequest = WebRequest.Create(url);
                webRequest.Method = "POST";
                webRequest.ContentType = "text/xml;charset=utf-8";
                webRequest.ContentLength = requestBytes.Length;
                //send the request
                using (var sw = webRequest.GetRequestStream()) 
                {
                    sw.Write(requestBytes, 0, requestBytes.Length);
                }
                //get the response
                webResponse = webRequest.GetResponse();
                using (var sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    returnVal = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
            }
            finally
            {
                try
                {
                if (webRequest.GetRequestStream() != null)
                    webRequest.GetRequestStream().Close();
                if (webResponse.GetResponseStream() != null)
                    webResponse.GetResponseStream().Close();
                }
                catch (Exception exw)
                {
                   
                    errorMessage = exw.ToString();
                }
                              
                
               
            }
     
