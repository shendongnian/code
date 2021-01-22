            public static Dictionary<int, string[]> MergeArrays2(IEnumerable<int> idCollection,
            params IEnumerable<string>[] valueCollections)
        {
            var dict = new Dictionary<int, string[]>();
            var valEnums = (from v in valueCollections select v.GetEnumerator()).ToList();
            foreach (int id in idCollection)
            {
                var strings = new List<string>();
                foreach (var e in valEnums)
                    if (e.MoveNext())
                        strings.Add(e.Current);
                dict.Add(id, strings.ToArray());
            }
            return dict;
        }
