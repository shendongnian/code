    class MyTestClass
    {
        void test() 
        {
            string message = _viewModel.DoWork();
            MyAssert.StringFormatConforms(message, Resource.MyResourceText);
        }
    }
    
    class MyAssert
    {
        public static void StringFormatConforms(string stringToCheck, string format)
        {
            // replace {0}, {1} with .*
            string regex = "^" + Regex.Replace(format, "{[0-9]+}", ".*") + "$";
            bool conforms = Regex.IsMatch(stringToCheck, regex);
            if (!conforms)
                throw new AssertFailedException(String.Format("The string {0} does not conforms to format: {1}", stringToCheck, format));
        }
    }
