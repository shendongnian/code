        public static List<Square> GetGroup(int match, Model grid, Square leader)
        {
            Stack<Square> curStack = new Stack<Square>(); 
            Dictionary<Square, bool> Retval = new Dictionary<Square, bool>(); 
            curStack.Push(leader);
            Retval.Add(leader, true);
            int numMatch = 1;
            while (curStack.Count != 0)
            {
                Square curItem = curStack.Pop(); 
                foreach (Square s in curItem.Neighbors) 
                {
                    if (Retval.ContainsKey(curItem))
                        continue;
                    if (0 != ((int)(s.RoomType) & match))
                    {
                        curStack.Push(s);
                        Retval.Add(s, true);
                        ++numMatch;
                    }
                    else
                    {
                        Retval.Add(s, false);
                    }
                }
            }
            // LINQ makes this easier, but since you're using .NET 2.0...
            List<Square> matches = new List<Square>(numMatch);
            foreach (KeyValuePair<Square, bool> kvp in Retval)
            {
                if (kvp.Value == true)
                {
                    matches.Add(kvp.Key);
                }
            }
            return matches;
        }
