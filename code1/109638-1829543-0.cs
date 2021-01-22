        public static IEnumerable<string> GetStrings(ArrayList list)
        {
            foreach(var item in list)
            {
                var @string = item as string;
                if (@string != null)
                    yield return @string;
                var nestedList = item as ArrayList;
                if(nestedList == null) 
                    continue;
                foreach (var childString in GetStrings(nestedList))
                    yield return childString;
            }
        }
