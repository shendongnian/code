    private class MyTagBuilder: TagBuilder
    {
        private static readonly MethodInfo tagBuilderAttrSetMethod = typeof(TagBuilder).GetProperty(nameof(Attributes)).SetMethod;
        public MyTagBuilder(string tagName) : base(tagName)
        {
            // TagBuilder internally uses SortedDictionary, render attributes according to the order they are added instead
            tagBuilderAttrSetMethod.Invoke(this, new object[] { new Dictionary<string, string>() });
        }
    }
