    public class YourDataClass {
        private static Regex regex = new Regex(@"{ Engineer = (?<Name>.*), HandHeldAvailability", RegexOptions.Compiled);
        public string GetNameFromInput(string input) {
            var result = string.Empty;
            Match match = regex.Match(input);
            if(match.Success && match.Groups["Name"] != null)
            {
                result = match.Groups["Name"].Value;
            }
            return result;
        }
    }
