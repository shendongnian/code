        public static class StringExtension {
            private static Dictionary<string, string> _replacements = new Dictionary<string, string>();
            static StringExtension() {
                _replacements["&"] = "and";
                _replacements[","] = "";
                _replacements["  "] = " ";
                // etc...
            }
            public static string clean(this string s) {
                foreach (string to_replace in _replacements.Keys) {
                    s = s.Replace(to_replace, _replacements[to_replace]);
                }
                return s;
            }
        }
