        public Dictionary<int, string[]> MergeArrays(
            IEnumerable<int> idCollection,
            params IEnumerable<string>[] valueCollections
                )
        {
            Dictionary<int, int> ids = idCollection
                .ToDictionaryByIndex();
            //
            Dictionary<int, List<string>> values =
                valueCollections.Select(x => x.ToList())
                .ToList()
                .Pivot()
                .ToDictionaryByIndex();
            //
            Dictionary<int, string[]> result =
                ids.ToDictionary(
                    z => z.Value,
                    z => values[z.Key].ToArray()
                );
            return result;
        }
