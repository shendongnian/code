    static void Main(string[] args) {     
        // UGLY HACK!       
        var verbType = typeof(HttpWebRequest).Assembly.GetType("System.Net.KnownHttpVerb");
        var getMethodField = verbType.GetField("Get", BindingFlags.Static | BindingFlags.NonPublic);
        var getMethod = getMethodField.GetValue(null);
        verbType.GetField("ContentBodyNotAllowed", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(getMethod, false);
        var jsonPayload = JsonConvert.SerializeObject(new { });
        var request = new HttpRequestMessage(HttpMethod.Get, "http://www.stackoverflow.com")
        {
            Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json")
        };
        var client = new HttpClient();
        var response = client.SendAsync(request).Result;
        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);            
    }
