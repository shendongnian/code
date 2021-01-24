    static class Program
    {
        static readonly Regex regex = new Regex(@"
    \(                    # Match (
    (
        [^()]+            # all chars except ()
        | (?<Level>\()    # or if ( then Level += 1
        | (?<-Level>\))   # or if ) then Level -= 1
    )+                    # Repeat (to go from inside to outside)
    (?(Level)(?!))        # zero-width negative lookahead assertion
    \)                    # Match )",
            RegexOptions.IgnorePatternWhitespace);
        /// <summary>
        /// Program Entry Point
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        static void Main(string[] args)
        {
            var input = "method(arg1,arg2,arg3(x));";
            var match = regex.Match(input);
            if(match != null)
            {
                string method = input.Substring(0, match.Index);                        // "method"
                string inside_parens = input.Substring(match.Index+1, match.Length-2);  // "arg1,arg2,arg3"   
                string remainer = input.Substring(match.Index+match.Length);            // ";"
                string[] arguments = inside_parens.Split(',');
                // recreate the input
                Debug.WriteLine($"{method}({string.Join(",", arguments)});");
                // Output: "method(arg1,arg2,arg3(x));"
            }
        }
    }
