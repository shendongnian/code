    try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(YOURURL);
                    request.ContentType = "application/json; charset=utf8";
                    request.Headers.Add(ADD HEADER HERE IF YOU NEED ONE);
                    request.Method = WebRequestMethods.Http.Post; // IMPORTANT
    
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                         streamWriter.Write(JsonConvert.SerializeObject(JSONBODYSTRING)); 
    // I USUALLY YOU JSONCONVERT HERE TO SIMPLY SERIALIZE A STRING CONTAINING THE JSON INFO. 
    //BUT I GUESS YOUR METHOD WOULD ALSO WORK
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
    
                    WebResponse response = request.GetResponse();
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        // DO WHATEVER YOU'D LIKE HERE
                    }
                } catch (Exception ex)
                {
                   // HANDLE YOUR EXCEPTIONS
                }
