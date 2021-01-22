        public static string Reverse(this string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        ...
        string hello = "olleh".Reverse();
