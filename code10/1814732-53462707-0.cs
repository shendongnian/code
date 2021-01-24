      HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.alfatah.pk/");
                request.UserAgent = $"Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 70.0.3538.77 Safari / 537.36"; ";
               request.Headers.Add(HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                request.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE");
    
                using (var response = (HttpWebResponse)(request.GetResponse()))
                {
                    HttpStatusCode code = response.StatusCode;
                    if (code == HttpStatusCode.OK)
                    {
                        using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                        {
                            HtmlDocument htmlDoc = new HtmlDocument();
                            htmlDoc.OptionFixNestedTags = true;
                            htmlDoc.Load(sr);
                        }
                    }
                }
