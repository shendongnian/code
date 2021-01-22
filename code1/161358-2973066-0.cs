    try
            {
                List<Uri> uris = new List<Uri>();
                uris.Add(new Uri("http://www.google.fr"));
                uris.Add(new Uri("http://www.bing.com"));
                Parallel.ForEach(uris, u =>
               {
                   WebRequest webR = HttpWebRequest.Create(u);
                   HttpWebResponse webResponse = webR.GetResponse() as HttpWebResponse;
               });
            }
            catch (AggregateException exc)
            {
                exc.InnerExceptions.ToList().ForEach(e =>
                    {
                        Console.WriteLine(e.Message);
                    });
            }
