    public static string GetUserBrowser(string userAgent)
            {
                // get a parser with the embedded regex patterns
                var uaParser = Parser.GetDefault();
                ClientInfo c = uaParser.Parse(userAgent);
                return c.UserAgent.Family;
            }
     public static string GetUserOS(string userAgent)
            {
                // get a parser with the embedded regex patterns
                var uaParser = Parser.GetDefault();
                ClientInfo c = uaParser.Parse(userAgent);
                return c.OS.Family;
            }
