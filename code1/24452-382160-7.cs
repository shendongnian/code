    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    static class extensions
    {
        public static bool IsSubSetOf(this string InputString, string MatchString)
        {
            var InputChars = InputString.ToList();
            MatchString.ToList().ForEach(Item => InputChars.Remove(Item));
            return InputChars.Count == 0;
        }
    }
