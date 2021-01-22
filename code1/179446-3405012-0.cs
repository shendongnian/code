            Regex r;
            Match m;
            r = new Regex(@"Mnemonic=(\S*);",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);
            for (m = r.Match(source); m.Success; m = m.NextMatch())
            {
                Console.WriteLine(m.Groups[1] + " at "
                + m.Groups[1].Index);
            }
