    public class Group
    {
        ...
        public IEnumerable<object> Items
        {
            get
            {
                foreach (var group in this.SubGroups)
                    yield return group;
                foreach (var entry in this.Entries)
                    yield return entry;
            }
        }
    }
