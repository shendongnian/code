        private string UrlDecode(string input)
        {
            string unescaped = null;
            try
            {
                unescaped = Uri.UnescapeDataString(input);
            }
            catch
            {
                unescaped = input;
                for (; ; )
                {
                    var match = Regex.Match(unescaped, @"\%[A-F0-9]{2}");
                    if (!match.Success)
                        break;
                    byte b;
                    try
                    {
                        b = byte.Parse(match.Value.Substring(1), NumberStyles.HexNumber);
                    }
                    catch
                    {
                        return HttpUtility.UrlDecode(input);
                    }
                    var replacement = Encoding.GetEncoding(1252).GetString(new[] { b });
                    unescaped = unescaped.Substring(0, match.Index) + replacement + unescaped.Substring(match.Index + match.Length);
                }
            }
            return unescaped;
        }
