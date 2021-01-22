            IEnumerable<String> lexicalStrings = new List<String> { "test", "t" };
            IEnumerable<String> allLexicals = new List<String> { "test", "Test", "T", "t" };
            IEnumerable<String> lexicals = new List<String>();
            foreach (String s in lexicalStrings)
            {
                lexicals = lexicals.Union(
                    allLexicals.Where(
                    lexical =>
                    {
                        Console.WriteLine(s);
                        return lexical == s;
                    }
                    )
                );
            }
            Console.WriteLine();
            foreach (var item in lexicals)
            {
            }
