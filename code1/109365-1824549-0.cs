        private static JsonParseException ProcessException(WebException webEx)
        {
            var stream = webEx.Response.GetResponseStream();
            using (var memory = new MemoryStream())
            {
                var buffer = new byte[4096];
                var read = 0;
                do
                {
                    read = stream.Read(buffer, 0, buffer.Length);
                    memory.Write(buffer, 0, read);
                } while (read > 0);
                memory.Position = 0;
                int pageSize = (int)memory.Length;
                byte[] bytes = new byte[pageSize];
                memory.Read(bytes, 0, pageSize);
                memory.Seek(0, SeekOrigin.Begin);
                string data = new StreamReader(memory).ReadToEnd();
                memory.Close();
                DefaultMeta meta = JsonConvert.DeserializeObject<DefaultMeta>(data);
                return new JsonParseException(meta.Meta, meta.Meta.Error, webEx);
            }
        }
