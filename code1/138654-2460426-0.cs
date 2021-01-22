            Uri uri = new Uri(""); // Here goes uri to the file.
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    // Process response.
                }
            }
