    /// <summary>
    /// Provides shared helper functionality for working with Windows process command-lines.
    /// </summary>
    internal static class WindowsCommandLineHelper
    {
        /// <summary>
        /// Performs escaping and quoting of arguments where necessary to
        /// build up a command-line suitable for use with the
        /// <see cref="Process.Start" /> method.
        /// </summary>
        /// <param name="arguments">The arguments to be included on the command-line.</param>
        /// <returns>The resulting command-line.</returns>
        public static string FormatCommandLine(params string[] arguments)
        {
            arguments = (string[])arguments.Clone();
            for (int index = 0; index < arguments.Length; index++)
            {
                arguments[index] = GetQuotedArgument(arguments[index]);
            }
            return string.Join(" ", arguments);
        }
        private static string GetQuotedArgument(string argument)
        {
            // The method reads the input argument backwards and builds
            // the result in reverse-character order.
            StringBuilder resultBuilder = new StringBuilder();
            // If the text has whitespace, it must be surrounded in quotes.
            bool surroundingQuotesRequired = HasWhitespace(argument);
            // This flag tracks whether the last character processed was a
            // quote or a backslash that belongs to a sequence of backslashes
            // that immediately precede a quote.
            bool precedingQuote = false;
            // If surrounding quotes are required, start with one.
            // This means that any slashes at the end must be doubled up,
            // so we must also set the precedingQuote flag.
            if (surroundingQuotesRequired)
            {
                resultBuilder.Append('"');
                precedingQuote = true;
            }
            // Read the argument string backwards, escaping any quotes and backslashes
            // where necessary (backslashes are OK unless in a sequence preceding a quote).
            for (int index = argument.Length - 1; index >= 0; index--)
            {
                char character = argument[index];
                resultBuilder.Append(character);
                if (character == '"')
                {
                    precedingQuote = true;
                    resultBuilder.Append('\\');
                }
                else if (character == '\\' && precedingQuote)
                {
                    resultBuilder.Append('\\');
                }
                else
                {
                    precedingQuote = false;
                }
            }
            // If surrounding quotes are required, add one.
            if (surroundingQuotesRequired)
            {
                resultBuilder.Append('"');
            }
            // Reverse the result and we're done.
            return Reverse(resultBuilder.ToString());
        }
        private static bool HasWhitespace(string argument)
        {
            // Iterate over the string and return true if it contains any whitespace characters.
            foreach (char character in argument)
            {
                if (char.IsWhiteSpace(character))
                {
                    return true;
                }
            }
            return false;
        }
        private static string Reverse(string input)
        {
            // Convert the string to a character array, reverse the order
            // and convert it back.
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
