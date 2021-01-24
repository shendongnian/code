        public static async Task<string> Convertbase64Async (Stream stream)
        {
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);
            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }
