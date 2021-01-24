    using System.Text.RegularExpressions;
        static bool Answer(string stringToTest)
        {
            var classifier = @"^\d\d[a-zA-Z]";
            Regex regex = new Regex(classifier);
            return regex.Match(stringToTest).Success;
        }
