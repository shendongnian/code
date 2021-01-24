    internal static class StringFileExtension
    {
        public static bool EndsWithFromList(this string fileInfo, List<string> fileExtensions)
        {
            foreach (var extension in fileExtensions)
            {
                if (fileInfo.EndsWith(extension))
                    return true;
            }
            return false;
        }
    }
