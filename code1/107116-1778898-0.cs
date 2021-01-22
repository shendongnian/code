    public static string ToSlug(this string text)
            {
                StringBuilder sb = new StringBuilder();
                var lastWasInvalid = false;
                foreach (char c in text)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        sb.Append(c);
                        lastWasInvalid = false;
                    }
                    else
                    {
                        if (!lastWasInvalid)
                            sb.Append("-");
                        lastWasInvalid = true;
                    }
                }
    
                return sb.ToString().ToLowerInvariant().Trim();
          
            }
