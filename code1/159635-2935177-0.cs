        private static IEnumerable<string> Parse(string input)
        {
            const string partPattern = @"([A-Fa-f0-9]{1,4})";
            string longPattern = string.Format(@"{0} (?:\:{0})*", partPattern); //Group 1 -> 2
            string compactPattern = string.Format(@"{0} (?:\:{0})* \:\: {0} (?:\:{0})*", partPattern, RegexOptions.IgnorePatternWhitespace); //Groups 3 ->6
            string completePattern = string.Format(@"^{0}$ | ^{1}$", longPattern, compactPattern);
            var match = Regex.Match(input, completePattern, RegexOptions.IgnorePatternWhitespace);
            if (match.Success)
            {
                if (match.Groups[1].Success)
                {
                    yield return match.Groups[1].Value.PadLeft(4, '0');
                    for (int i = 0; i < match.Groups[2].Captures.Count; ++i)
                        yield return match.Groups[2].Captures[i].Value.PadLeft(4, '0');
                }
                else
                {
                    var count = 6 - match.Groups[4].Captures.Count - match.Groups[6].Captures.Count;
                    //First part
                    yield return match.Groups[3].Value.PadLeft(4, '0');
                    for (int i = 0; i < match.Groups[4].Captures.Count; ++i)
                        yield return match.Groups[4].Captures[i].Value.PadLeft(4, '0');
                    //:: block
                    for (int i = 0; i < count; ++i)
                        yield return "0000";
                    //Second part
                    yield return match.Groups[5].Value.PadLeft(4, '0');
                    for (int i = 0; i < match.Groups[6].Captures.Count; ++i)
                        yield return match.Groups[6].Captures[i].Value.PadLeft(4, '0');
                }
            }
            else
                throw new Exception("No match");
        }
