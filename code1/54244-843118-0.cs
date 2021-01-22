                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"http://somedomain.com/file");               
                                                                               
                //Set some reasonable limits on resources used by this request
                request.MaximumAutomaticRedirections = 4;
                request.MaximumResponseHeadersLength = 4;
                request.Timeout = 15000;
                
       response = (HttpWebResponse)request.GetResponse();                              
              
                    Stream receiveStream = response.GetResponseStream();
                    Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                    StreamReader readStream = new StreamReader(receiveStream, encode);
                    Char[] read = new Char[512];
                    // Reads 512 characters at a time.
                    int count = readStream.Read(read, 0, 512);
                   
                    while (count > 0)
                    {
                        // Dumps the 512 characters on a string and displays the string.
                        String str = new String(read, 0, count);
                        count = readStream.Read(read, 0, 512);
                    }
