            List<string> contents = new List<string>();
            contents.Add("55");
            contents.Add("some text");
            contents.Add("a lone 5");
            ConcurrentDictionary<int, string> concurrent = new ConcurrentDictionary<int, string>();
            Parallel.For(0, contents.Count, i => concurrent[i] = Parse(contents[i]));
            foreach(string s in concurrent.Values)
            {
                Console.WriteLine(s);
            }
