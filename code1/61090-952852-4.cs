    /// <summary>
    /// Provides helper functionality for working with Windows process command-lines.
    /// </summary>
    public static class WindowsCommandLineHelper
    {
        /// <summary>
        /// Performs escaping and quoting of arguments where necessary to
        /// build up a command-line suitable for use with the
        /// <see cref="System.Diagnostics.Process.Start(string,string)" /> method.
        /// </summary>
        /// <param name="arguments">The arguments to be included on the command-line.</param>
        /// <returns>The resulting command-line.</returns>
        public static string FormatCommandLine(params string[] arguments)
        {
            return string.Join(" ", arguments.Select(GetQuotedArgument));
        }
        private static string GetQuotedArgument(string argument)
        {
            // The argument is processed in reverse character order.
            // Any quotes (except the outer quotes) are escaped with backslash.
            // Any sequences of backslashes preceding a quote (including outer quotes) are doubled in length.
            var resultBuilder = new StringBuilder();
            var outerQuotesRequired = HasWhitespace(argument);
            var precedingQuote = false;
            if (outerQuotesRequired)
            {
                resultBuilder.Append('"');
                precedingQuote = true;
            }
            for (var index = argument.Length - 1; index >= 0; index--)
            {
                var @char = argument[index];
                resultBuilder.Append(@char);
                if (@char == '"')
                {
                    precedingQuote = true;
                    resultBuilder.Append('\\');
                }
                else if (@char == '\\' && precedingQuote)
                {
                    resultBuilder.Append('\\');
                }
                else
                {
                    precedingQuote = false;
                }
            }
            if (outerQuotesRequired)
            {
                resultBuilder.Append('"');
            }
            return Reverse(resultBuilder.ToString());
        }
        private static bool HasWhitespace(string text)
        {
            return text.Any(char.IsWhiteSpace);
        }
        private static string Reverse(string text)
        {
            return new string(text.Reverse().ToArray());
        }
    }
