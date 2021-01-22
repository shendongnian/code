        public string RemoveFirstCharFromString(string Text)
        {
            string[] arr1 = new string[] { "The ", "A " };
            string Original = Text.ToLower();
            if (Text.Length > 4)
            {
                foreach (string match in arr1)
                {
                    if (Original.StartsWith(match.ToLower()))
                    {
                        //Original = Original.Replace(match.ToLower(), "").TrimStart();
                        Original = Original.Replace(Original.Substring(0, match.Length), "").TrimStart();
                        return Original;
                    }
                }
            }
            return Original;
        }
