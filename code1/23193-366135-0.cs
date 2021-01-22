        public static string MakeTinyUrl(string url)
        {
            try
            {
                if (url.Length <= 30)
                {
                    return url;
                }
                if (!url.ToLower().StartsWith("http") && !Url.ToLower().StartsWith("ftp"))
                {
                    url = "http://" + url;
                }
                var request = WebRequest.Create("http://tinyurl.com/api-create.php?url=" + url);
                var res = request.GetResponse();
                string text;
                using (var reader = new StreamReader(res.GetResponseStream()))
                {
                    text = reader.ReadToEnd();
                }
                return text;
            }
            catch (Exception)
            {
                return url;
            }
        }
