        public static string returnSafeString(string result)
        {
            result = result.Replace(Path.GetInvalidFileNameChars().ToString(), string.Empty);
            result = result.Replace(Path.GetInvalidPathChars().ToString(), string.Empty);
            return result;
        }
        
