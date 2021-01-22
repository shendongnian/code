        public static string AppendToList(this String s, string item, string delim) {
            if (s.Length == 0) {
                return item;
            }
            return s+delim+item;
        }
