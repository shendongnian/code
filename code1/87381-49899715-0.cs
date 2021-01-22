    public static class StringExtension
    {
        private const string parentSymbol = "..\\";
        private const string absoluteSymbol = ".\\";
        public static String AbsolutePath(this string relativePath)
        {
            string replacePath = AppDomain.CurrentDomain.BaseDirectory;
            int parentStart = relativePath.IndexOf(parentSymbol);
            int absoluteStart = relativePath.IndexOf(absoluteSymbol);
            if (parentStart >= 0)
            {
                int parentLength = 0;
                while (relativePath.Substring(parentStart + parentLength).Contains(parentSymbol))
                {
                    replacePath = new DirectoryInfo(replacePath).Parent.FullName;
                    parentLength = parentLength + parentSymbol.Length;
                };
                relativePath = relativePath.Replace(relativePath.Substring(parentStart, parentLength), string.Format("{0}\\", replacePath));
            }
            else if (absoluteStart >= 0)
            {
                relativePath = relativePath.Replace(".\\", replacePath);
            }
            return relativePath;
        }
    }
