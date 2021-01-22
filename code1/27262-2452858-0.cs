    using NDde.Client;
    
    class Test
    {
            public static string GetFirefoxURL()
            {
                DdeClient dde = new DdeClient("Firefox", "WWW_GetWindowInfo");
                dde.Connect();
                string url = dde.Request("URL", int.MaxValue);
                dde.Disconnect();
                return url;
            }
    }
