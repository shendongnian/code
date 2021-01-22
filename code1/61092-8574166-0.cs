        public static string QuoteArgument(string arg)
        {
            // The inverse of http://msdn.microsoft.com/en-us/library/system.environment.getcommandlineargs.aspx
            // Suppose we wish to get after unquoting: \\share\"some folder"\
            // We should provide: "\\share\\\"some folder\"\\"
            // Escape quotes ==> \\share\\\"some folder\"\
            // For quotes with N preceding backslashes, replace with 2k+1 preceding backslashes.
            var res = new StringBuilder();
            // For sequences of backslashes before quotes:
            // odd ==> 2x+1, even => 2x ==> "\\share\\\"some folder"
            var numBackslashes = 0;
            for (var i = 0; i < arg.Length; ++i)
            {
                if(arg[i] == '"')
                {
                    res.Append('\\', 2 * numBackslashes + 1);
                    res.Append('"');
                    numBackslashes = 0;
                }
                else if(arg[i] == '\\')
                {
                    numBackslashes++;
                }
                else
                {
                    res.Append('\\', numBackslashes);
                    res.Append(arg[i]);
                    numBackslashes = 0;
                }
            }
            res.Append('\\', numBackslashes);
            // Enquote, doubling last sequence of backslashes ==> "\\share\\\"some folder\"\\"
            var numTrailingBackslashes = 0;
            for (var i = res.Length - 1; i > 0; --i)
            {
                if (res[i] != '\\')
                {
                    numTrailingBackslashes = res.Length - 1 - i;
                    break;
                }
            }
            res.Append('\\', numTrailingBackslashes);
            return '"' + res.ToString() + '"';
        }
