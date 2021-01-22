        public static string ExtractDomainName(string Url)
        {
            return System.Text.RegularExpressions.Regex.Replace(
            Url,
            @"^([a-zA-Z]+:\/\/)?([^\/]+)\/.*?$",
            "$2"
            );
        } 
