            HttpClient client = new HttpClient();
            HttpResponseMessage wcfResponse = client.GetAsync(string.Format("http://localhost:7510/Calc.svc/xmlData/{0}", "hello")).Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync();
            Label.Text = data.Result;
