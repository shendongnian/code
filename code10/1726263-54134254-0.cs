        public static async Task<T> As<T>(this Task<HttpResponseMessage> task)
        {
            var response = await task.ConfigureAwait(false);
            return await response.As<T>();
        }
        public static async Task<T> As<T>(this HttpResponseMessage message)
        {
            var json = await message.Content.ReadAsStringAsync();
            return Json.Deserialize<T>(json);
        }
