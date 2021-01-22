            Stream connection = new MemoryStream(""); // Just a placeholder
            WebClient wc = new WebClient();
            string contentType;
            try
            {
                connection = wc.OpenRead(current.Url);
                contentType = wc.ResponseHeaders["content-type"];
            }
            catch (Exception)
            {
                // 404 or what have you
            }
            finally
            {
                connection.Close();
            }
