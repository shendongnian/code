        private async Task GetResponseAsync(Uri uri, Action<Response> callback) {
            System.Net.Http.HttpClient wc = new HttpClient();
            var response = await wc.GetAsync(uri);
            if (callback != null) {
                var stream = await response.Content.ReadAsStreamAsync();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                callback(ser.ReadObject(stream) as Response);
            }
        }
