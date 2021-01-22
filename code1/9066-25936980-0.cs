     static string SanitiseFilename(string key)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            var sb = new StringBuilder();
            foreach (var c in key)
            {
                var invalidCharIndex = -1;
                for (var i = 0; i < invalidChars.Length; i++)
                {
                    if (c == invalidChars[i])
                    {
                        invalidCharIndex = i;
                    }
                }
                if (invalidCharIndex > -1)
                {
                    sb.Append("_").Append(invalidCharIndex);
                    continue;
                }
                if (c == '_')
                {
                    sb.Append("__");
                    continue;
                }
                sb.Append(c);
            }
            return sb.ToString();
        }
