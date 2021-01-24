        static string NormalizeSuperscript(string s)
        {
            var sb = new StringBuilder();
            foreach (var superC in s)
            {
                if(TryNormalizeSuperscript(superC, out char c))
                {
                    sb.Append(c);
                }
                else
                {
                    break;
                }
            }
            return sb.ToString();
        }
