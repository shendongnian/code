            private string FormatPermalink(string title)
            {
                StringBuilder result = new StringBuilder();
                title = title.Trim();
                bool lastOneChanged = false;
                for (int i = 0; i < title.Length; i++)
                {
                    char c = title[i];
                    if (!char.IsLetterOrDigit(c))
                    {
                        c = '_';
                        if (lastOneChanged)
                        {
                            continue;
                        }
                        lastOneChanged = true;
                    }
    
                    else
                    {
                        lastOneChanged = false;
                    }
    
                    result.Append(c);
                }
    
                if (result[result.Length - 1] == '_') //if last one is underscore, remove
                {
                    result = result.Remove(result.Length - 1, 1);
                }
                return result.ToString();
            }
