    public static IEnumerable<IEnumerable<T>> GetSubSets<T>(IEnumerable<T> source)
        {
            var result = new List<IEnumerable<T>>() { new List<T>() }; // empty cluster  added
            for (int i = 0; i < source.Count(); i++)
            {
                var elem = source.Skip(i).Take(1);
                // for elem = 2
                // and currently result = [ [],[1] ]
                var matchUps = result.Select(x => x.Concat(elem));
                //then matchUps => [ [2],[1,2] ]
                 result = result.Concat(matchUps).ToList();
                //  matchUps and result concat operation
                // finally result = [ [],[1],[2],[1,2] ]
            }
            return result;
        }
