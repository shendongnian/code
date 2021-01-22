        public static IEnumerable<string> Split(this string str, 
                                                Func<char, bool> controller)
        {
            int nextPiece = 0;
            for (int c = 0; c < str.Length; c++)
            {
                if (controller(str[c]))
                {
                    yield return str.Substring(nextPiece, c - nextPiece);
                    nextPiece = c + 1;
                }
            }
            yield return str.Substring(nextPiece);
        }
