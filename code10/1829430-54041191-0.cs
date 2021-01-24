            List<string> contents = new List<string>();
            contents.Add("55");
            contents.Add("some text");
            contents.Add("a lone 5");
            List<string> parsed = new List<string>();
            // here, i is the index of the for loop.
            Parallel.For(0, contents.Count, i => parsed.Add(Parse(contents[i])));
            foreach(string s in parsed)
            {
                Console.WriteLine(s);
            }
