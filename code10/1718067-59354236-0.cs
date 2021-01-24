        public static async Task<string> SerializeJsonAsync(object value)
        {
            using (var ms = new MemoryStream())
            using (var sr = new StreamReader(ms))
            using (var sw = new StreamWriter(ms, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                await jtw.FlushAsync();
                await jtw.CloseAsync();
                ms.Position = 0;
                string s = await sr.ReadToEndAsync();
                return s;
            }
        }
