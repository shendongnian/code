    public static class AssertValid
    {
        public static void TestAssertValid()
        {
            var customerId = 0;
            AssertValid.MinimumFor(customerId, 1, nameof(customerId));
        }
        public static void RangeFor<T>(T variableValue, T min, T max, string varName,
            string message = "Variable {0} outside of range {1} to {2} in function {3}",
            [CallerMemberName] string inFunc = "") where T : IComparable
        {
            if (variableValue.CompareTo(min) < 0 || variableValue.CompareTo(max) > 0)
            {
                var msg = string.Format(message, varName, min, max, inFunc);
                throw new ArgumentOutOfRangeException(varName, variableValue, msg);
            }
        }
        public static void MinimumFor<T>(T variableValue, T min, string varName,
            string message = "Variable {0} less than minimum of {1} in function {2}",
            [CallerMemberName] string inFunc = "") where T : IComparable
        {
            if (variableValue.CompareTo(min) < 0)
            {
                var msg = string.Format(message, varName, min, inFunc);
                throw new ArgumentOutOfRangeException(varName, variableValue, msg);
            }
        }
        public static void MaximumFor<T>(T variableValue, T min, string varName,
            string message = "Variable {0} greater than maximum of {1} in function {2}",
            [CallerMemberName] string inFunc = "") where T : IComparable
        {
            //...
        }
        public static void StringLengthRangeFor(string variableValue, int min, int max, string varName,
            string message = "Length of string variable {0} outside of range {1} to {2} in function {3}",
            [CallerMemberName] string inFunc = "")
        {
            if (variableValue.Length < min || variableValue.Length > max)
            {
                var msg = string.Format(message, varName, min, max, inFunc);
                throw new ArgumentOutOfRangeException(varName, variableValue, msg);
            }
        }
        public static void StringLengthMinFor(string variableValue, int min, int max, string varName,
            string message = "Length of string variable {0} less than {1} characters in function {2}",
            [CallerMemberName] string inFunc = "")
        {
            if (variableValue.Length < min)
            {
                var msg = string.Format(message, varName, min, inFunc);
                throw new ArgumentOutOfRangeException(varName, variableValue, msg);
            }
        }
        public static void StringLengthMaxFor(string variableValue, int max, string varName,
            string message = "Length of string variable {0} greater than {1} characters in function {2}",
            [CallerMemberName] string inFunc = "")
        {
            //...
        }
        public static void StringLengthPatternFor(string variableValue, string regexPattern, string varName,
            string message = "String variable {0} does not match acceptable pattern in function {1}",
            [CallerMemberName] string inFunc = "")
        {
            //... Use ArgumentException
        }
    }
