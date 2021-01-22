        static string RefactoredMakeNiceString2(string str)
        {
            char[] ca = str.ToCharArray();
            StringBuilder sb = new StringBuilder(str.Length);
            int start = 0;
            for (int i = 0; i < ca.Length; i++)
            {
                if (char.IsUpper(ca[i]) && i != 0)
                {
                    sb.Append(ca, start, i - start);
                    sb.Append(' ');
                    start = i;
                }
            }
            sb.Append(ca, start, ca.Length - start);
            return sb.ToString();
        }
