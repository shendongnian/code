            Dictionary<string, IEnumerable<int>> WordsPositions = new Dictionary<string, IEnumerable<int>>();
            IEnumerable<int> IndexOfAll = null;
            foreach (string st in Susbtrings)
            {
                IndexOfAll = Regex.Matches(input, st).Cast<Match>().Select(m => m.Index);
                WordsPositions.Add(st, IndexOfAll);
            }
            return WordsPositions;
        }
