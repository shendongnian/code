    public void SetFieldValue(string value, string path, int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Base64authorizationToken());
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartArray(); // [
                    writer.WriteStartObject(); // {
                    writer.WritePropertyName("op"); // "Product:"
                    writer.WriteValue("replace");
                    writer.WritePropertyName("path");
                    writer.WriteValue(path);
                    writer.WritePropertyName("value");
                    writer.WriteValue(value);
                    writer.WriteEndObject(); //}
                    writer.WriteEnd(); // ]
                }
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, PatchwebAPIUrl("wit/workitems", id.ToString())) { Content =  new StringContent(sb.ToString().Trim(new char[] {'{','}'}), Encoding.UTF8, "application/json-patch+json") };
                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
