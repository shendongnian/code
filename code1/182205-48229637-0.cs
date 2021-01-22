    private class MyTagBuilder: TagBuilder
    {
        public MyTagBuilder(string tagName) : base(tagName)
        {
            // TagBuilder internally uses SortedDictionary, render attributes according to the order they are added instead
            typeof(TagBuilder).GetProperty(nameof(Attributes)).SetValue(this, new Dictionary<string, string>());
        }
    }
