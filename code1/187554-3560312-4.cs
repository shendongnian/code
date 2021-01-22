    public bool ContainsDuplicate(List<List<int>> input)
    {
        var encounteredLists = new Dictionary<int, List<EnumerableWrapper>>();
        foreach (List<int> currentList in input)
        {
            var currentListWrapper = new EnumerableWrapper(currentList);
            int hash = currentListWrapper.GetHashCode();
            if (encounteredLists.ContainsKey(hash))
            {
                foreach (EnumerableWrapper currentEncounteredEntry in encounteredLists[hash])
                {
                    if (currentListWrapper.Equals(currentEncounteredEntry))
                        return true;
                }
            }
            else
            {
                var newEntry = new List<EnumerableWrapper>();
                newEntry.Add(currentListWrapper);
                encounteredLists[hash] = newEntry;
            }
        }
        return false;
    }
    sealed class EnumerableWrapper
    {
        public EnumerableWrapper(IEnumerable<int> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            this.List = list;
        }
        public IEnumerable<int> List { get; private set; }
        public override bool Equals(object obj)
        {
            bool result = false;
            var other = obj as EnumerableWrapper;
            if (other != null)
                result = Enumerable.SequenceEqual(this.List, other.List);
            return result;
        }
        public override int GetHashCode()
        {
            // Todo: Implement your own hashing algorithm here
            var sb = new StringBuilder();
            foreach (int value in List)
                sb.Append(value.ToString());
            return sb.ToString().GetHashCode();
        }
    }
