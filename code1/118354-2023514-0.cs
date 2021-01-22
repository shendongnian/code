    interface ITaggable {
        void AddTag(String tag);
    }
    class TaggableImplementation : ITaggable {
        private Hashset<String> tags = new Hashset<String>();
        public void AddTag(String tag) { tags.Add(tag); }
    }
    class TaggableClass : ITaggable {
        private ITaggable taggable = new TaggableImplementation();
        public void AddTag(String tag) { taggable.AddTag(tag); }
    }
