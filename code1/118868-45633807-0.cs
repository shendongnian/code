    public static bool CheckForInternetConnection(){
    
                try
                {
                    
                    using (var webClient = new WebClient())
                    using (var stream = webClient.OpenRead("http://captive.apple.com/hotspot-detect.html"))
                    {
                        if (stream != null)
                        {
                            //return true;
                            stream.ReadTimeout = 1000;
                            using (var reader = new StreamReader(stream, Encoding.UTF8, false))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (line == "<HTML><HEAD><TITLE>Success</TITLE></HEAD><BODY>Success</BODY></HTML>")
                                    {
                                        return true;
                                                                        }
                                    Console.WriteLine(line);
                                }
                            }
                            
                        }
                        return false;
                    }
    
    
                }
                catch
                {
    
                   
                }
                return false;
            }
