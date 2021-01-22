            /// <summary>
            /// Compute Levenshtein distance according to the Levenshtein Distance Algorithm
            /// </summary>
            /// <param name="s">String 1</param>
            /// <param name="t">String 2</param>
            /// <returns>Distance between the two strings.
            /// The larger the number, the bigger the difference.
            /// </returns>
            private static int Compare(string s, string t)
            {
                /* if both string are not set, its uncomparable. But others fields can still match! */
                if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t)) return 0;
    
                /* if one string has value and the other one hasn't, it's definitely not match */
                if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return -1;
    
                s = s.ToUpper().Trim();
                t = t.ToUpper().Trim();
    
                int n = s.Length;
                int m = t.Length;
                int[,] d = new int[n + 1, m + 1];
    
                int cost;
    
                if (n == 0) return m;
                if (m == 0) return n;
    
                for (int i = 0; i <= n; d[i, 0] = i++) ;
                for (int j = 0; j <= m; d[0, j] = j++) ;
    
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        cost = (t.Substring(j - 1, 1) == s.Substring(i - 1, 1) ? 0 : 1);
    
                        d[i, j] = System.Math.Min(System.Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                                  d[i - 1, j - 1] + cost);
                    }
                }
    
                return d[n, m];
            }
