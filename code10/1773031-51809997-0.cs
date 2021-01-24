    static class CachedDataProvider
    {
        private static string response = null;
        public static string GetData()
        {
            if (response == null)
            {
                // consuming some api here
                response = "example response data";
            }
            return response;
        }
        
        public static void Invalidate()
        {
            response = null;
        }
    }
