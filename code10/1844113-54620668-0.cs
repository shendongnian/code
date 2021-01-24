     using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Host", "ec.europa.eu");
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv,65.0) Gecko/20100101 Firefox/65.0");
                client.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                client.Headers.Add("Accept-Language", "pl,en-US;q=0.7,en;q=0.3");
                client.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                client.Headers.Add("DNT", "1");
                client.Headers.Add("Cookie", "JSESSIONID=-(...); escoLanguage=en");
                var downloadStr = client.DownloadData(new Uri("https://ec.europa.eu/esco/portal/skill?uri=http%3A%2F%2Fdata.europa.eu%2Fesco%2Fskill%2F00735755-adc6-4ea0-b034-b8caff339c9f&conceptLanguage=en&full=true"));
                
                MemoryStream stream = new MemoryStream();
                using (GZipStream g = new GZipStream(new MemoryStream(downloadStr), CompressionMode.Decompress))
                {
                    g.CopyTo(stream);
                }
                var output=  Encoding.UTF8.GetString(stream.ToArray());
            }
