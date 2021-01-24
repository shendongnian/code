    public class RequestHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.RequestUri);
            request.RequestUri = new Uri(toEnglishNumber(request.RequestUri.ToString()));
            Console.WriteLine(request.RequestUri);
            return base.SendAsync(request, cancellationToken);
        }
        public static string toEnglishNumber(string input)
        {
            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            for (int j = 0; j < persian.Length; j++)
                input = input.Replace(persian[j], j.ToString());
            return input;
        }
    }
