        public static string GetResponseFromServer()
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("sID", "6"),
                    new KeyValuePair<string, string>("sName", "anas"),
                    new KeyValuePair<string, string>("sMajor", "prog"),
                });
                var result = client.PostAsync("Your URL Goes here", content);
                string resultContent = result.Result.Content.ReadAsStringAsync().Result;
                return resultContent;
            }
        }
