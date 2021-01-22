    class DarinDimitrovSolution
    {
        const string regExpression = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";
        private static readonly Regex _regex = new Regex(
            regExpression, RegexOptions.Compiled);
        public static bool IsAlphaAndNumeric_1(string s) {
            return _regex.IsMatch(s);
        }
        public static bool IsAlphaAndNumeric_0(string s) {
            return Regex.IsMatch(s, regExpression);
        }
