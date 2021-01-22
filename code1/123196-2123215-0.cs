                    using (WebClient client = new WebClient())
                    {
                        //manipulate request headers (optional)
                        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                        //execute request and read response as string to console
                        using (StreamReader reader = new StreamReader(client.OpenRead(url)))
                        {
                            string s = reader.ReadToEnd();
                            //Console.WriteLine(s);
                            Console.WriteLine("Vote " + i.ToString() + ": SUCCESS");
                            i++;
                        }
                    }
                    // *** Establish the request
                    HttpWebRequest loHttp =
                         (HttpWebRequest)WebRequest.Create(url);
                    // *** Set properties
                    loHttp.Timeout = 10000;     // 10 secs
                    loHttp.UserAgent = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    loHttp.Headers["Accept-Encoding"] = "gzip";
                    // *** Retrieve request info headers
                    HttpWebResponse loWebResponse = (HttpWebResponse)loHttp.GetResponse();
                    Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page
                    StreamReader loResponseStream =
                       new StreamReader(loWebResponse.GetResponseStream(), enc);
                    string lcHtml = loResponseStream.ReadToEnd();
                    loWebResponse.Close();
                    loResponseStream.Close();
                    if (lcHtml.Length > 0)
                    {
                        Console.WriteLine("Vote " + i.ToString() + ": SUCCESS");
                        i++;
                    }
                    else
                        Console.WriteLine("Vote " + i.ToString() + ": FAILED");
                }
                
