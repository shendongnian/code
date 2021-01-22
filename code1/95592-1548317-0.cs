        static class Extensions
        {
            public static int IndexOf(this StringBuilder sb, string value)
            {
                return sb.ToString().IndexOf(value);
            }
    
    //if you must use CharAt instead of indexer
            public static int CharAt(this StringBuilder sb, int index)
            {
                return sb[index];
            }
        }
