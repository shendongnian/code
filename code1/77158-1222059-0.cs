            string unescaped = null;
            var input = "http://en.wikipedia.org/wiki/Herbert_Gr%F6nemeyer";
            try
            {
                unescaped=Uri.UnescapeDataString(input);
            }
            catch
            {
                unescaped = input;
                for (; ; )
                {
                    var match = Regex.Match(unescaped, @"\%[A-F0-9]{2}");
                    if (!match.Success)
                        break;
                    byte b = byte.Parse(match.Value.Substring(1), NumberStyles.HexNumber);
                    var replacement = Encoding.GetEncoding(1252).GetString(new[] {b});
                    unescaped = unescaped.Substring(0, match.Index) + replacement + input.Substring(match.Index + match.Length);
                    
                }
            }
            Console.WriteLine(unescaped);
