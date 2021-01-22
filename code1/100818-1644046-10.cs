    public static class IRandomExtensions
    {
        // assuming 'CodeType' is in fact a string
        public static string GetCode (this IRandom random)
        {
            // 1. get as many random bytes as required
            byte[] randomBytes; // fill from random
            // 2. transform bytes into a 'Code'
            string randomBase64String = 
                System.Convert.ToBase64String (randomBytes).Trim ("=");
            // 3. bob's your uncle
            ...
        }
    }
