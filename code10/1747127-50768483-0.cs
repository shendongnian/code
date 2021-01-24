        public async Task<IActionResult> SendMessage(string encodedResponse)
        {
            var url = $"https://www.google.com/recaptcha/api/siteverify?secret=--secret-key--&response={encodedResponse}";
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(url, null))
                {
                    var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                    if (!(bool)json["success"])
                    {
                        return Unauthorized();
                    }
                }
            }
            // CODE HERE WHEN THE REQUEST IS OK
            return Ok();
        }
