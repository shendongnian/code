    string responseMessage;
                HttpClient client = new HttpClient(serviceUrl);
                HttpWebRequest request = WebRequest.Create(string.Concat(serviceUrl, resourceUrl)) as HttpWebRequest;
                request.ContentType = "text/xml";
                request.Method = method;
                HttpContent objContent = HttpContentExtensions.CreateDataContract(requestBody);
                if(method == "POST" && requestBody != null)
                {
                    //byte[] requestBodyBytes = ToByteArrayUsingXmlSer(requestBody, "http://schemas.datacontract.org/2004/07/XMLService");
                    byte[] requestBodyBytes = ToByteArrayUsingDataContractSer(requestBody);
                    request.ContentLength = requestBodyBytes.Length;
                    using (Stream postStream = request.GetRequestStream())
                        postStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
                    //request.Timeout = 60000;
                }
    
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
    
                    responseMessage = reader.ReadToEnd();
                }
                else
                {
                    responseMessage = response.StatusDescription;
                }
