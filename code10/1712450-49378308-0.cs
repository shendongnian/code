    public static class EmojiParser {
        static readonly Dictionary<string, string> _colonedEmojis;
        static readonly Regex _colonedRegex;
        static EmojiParser() {
            // load mentioned json from somewhere
            var data = JArray.Parse(File.ReadAllText(@"C:\path\to\emoji.json"));
            _colonedEmojis = data.OfType<JObject>().ToDictionary(
                // key dictionary by coloned short names
                c => ":" + ((JValue)c["short_name"]).Value.ToString() + ":",
                c => {
                    var unicodeRaw = ((JValue)c["unified"]).Value.ToString();
                    var chars = new List<char>();
                    // some characters are multibyte in UTF32, split them
                    foreach (var point in unicodeRaw.Split('-'))
                    {
                        // parse hex to 32-bit unsigned integer (UTF32)
                        uint unicodeInt = uint.Parse(point, System.Globalization.NumberStyles.HexNumber);
                        // convert to bytes and get chars with UTF32 encoding
                        chars.AddRange(Encoding.UTF32.GetChars(BitConverter.GetBytes(unicodeInt)));
                    }
                    // this is resulting emoji
                    return new string(chars.ToArray());
                });
            // build huge regex (all 1500 emojies combined) by join all names with OR ("|")
            _colonedRegex =  new Regex(String.Join("|", _colonedEmojis.Keys.Select(Regex.Escape)));
        }
        public static string ReplaceColonNames(string input) {
            // replace match using dictoinary
            return _colonedRegex.Replace(input, match => _colonedEmojis[match.Value]);
        }
    }
