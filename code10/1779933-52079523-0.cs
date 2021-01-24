    public static void ResetHttpClient()
    {
        Client = new HttpClient();
        if (isDevelopment) // however you determine it
        {
             Client.DefaultRequestHeaders
                   .TryAddWithoutValidation("Authorization", "Bearer hhxcshRT43bhJHjh53hkjhbhvghf54g5hbhkghfdUGUKGYFDJihu5");
             Client.DefaultRequestHeaders
                   .TryAddWithoutValidation("Cookie", "SessionID=36dab-3545-adef");
        }
    }
