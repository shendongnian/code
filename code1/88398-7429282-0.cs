    public static class EnumHelper
    {
        public static string ToDescription(Enum value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            if (!Enum.IsDefined(value.GetType(), value))
            {
                return string.Empty;
            }
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                DescriptionAttribute[] attributes =
                    fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false) as DescriptionAttribute[];
                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }
            return StringHelper.ToFriendlyName(value.ToString());
        }
    }
    public static class StringHelper
    {
        public static bool IsNullOrWhiteSpace(string value)
        {
            return value == null || string.IsNullOrEmpty(value.Trim());
        }
        public static string ToFriendlyName(string value)
        {
            if (value == null) return string.Empty;
            if (value.Trim().Length == 0) return string.Empty;
            string result = value;
            result = string.Concat(result.Substring(0, 1).ToUpperInvariant(), result.Substring(1, result.Length - 1));
            const string pattern = @"([A-Z]+(?![a-z])|\d+|[A-Z][a-z]+|(?![A-Z])[a-z]+)+";
            List<string> words = new List<string>();
            Match match = Regex.Match(result, pattern);
            if (match.Success)
            {
                Group group = match.Groups[1];
                foreach (Capture capture in group.Captures)
                {
                    words.Add(capture.Value);
                }
            }
            return string.Join(" ", words.ToArray());
        }
    }
        [TestMethod]
        public void TestFriendlyName()
        {
            string[][] cases =
                {
                    new string[] {null, string.Empty},
                    new string[] {string.Empty, string.Empty},
                    new string[] {" ", string.Empty}, 
                    new string[] {"A", "A"},
                    new string[] {"z", "Z"},
                    new string[] {"Pascal", "Pascal"},
                    new string[] {"camel", "Camel"},
                    
                    new string[] {"PascalCase", "Pascal Case"}, 
                    new string[] {"ABCPascal", "ABC Pascal"}, 
                    new string[] {"PascalABC", "Pascal ABC"}, 
                    new string[] {"Pascal123", "Pascal 123"}, 
                    new string[] {"Pascal123ABC", "Pascal 123 ABC"}, 
                    new string[] {"PascalABC123", "Pascal ABC 123"}, 
                    new string[] {"123Pascal", "123 Pascal"}, 
                    new string[] {"123ABCPascal", "123 ABC Pascal"}, 
                    new string[] {"ABC123Pascal", "ABC 123 Pascal"}, 
                    
                    new string[] {"camelCase", "Camel Case"}, 
                    new string[] {"camelABC", "Camel ABC"}, 
                    new string[] {"camel123", "Camel 123"}, 
                };
            foreach (string[] givens in cases)
            {
                string input = givens[0];
                string expected = givens[1];
                string output = StringHelper.ToFriendlyName(input);
                Assert.AreEqual(expected, output);
            }
        }
    }
