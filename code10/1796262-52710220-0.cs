        static IEnumerable<string> Tokenize(string input)
        {
            if (string.IsNullOrEmpty(input))
                yield break;
            if (')' != input[input.Length - 1])
                yield break;
            int colon = input.IndexOf(':');
            string pageData = input.Substring(colon + 1);
            if (string.IsNullOrEmpty(pageData))
                yield break;
            int open = pageData.IndexOf('(');
            if (colon != -1 && open != -1)
            {
                yield return input.Substring(0, colon+1);
                foreach (var token in pageData.Substring(open+1, pageData.Length - (open + 1) - 1).Split(','))
                    yield return token;
            }
        }
