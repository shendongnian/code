    public sealed class Foo
    {
        private readonly string text;
        private readonly int itemId;
        private readonly string path;
        public Foo(string text, int itemId, string path)
        {
            this.text = text;
            this.itemId = itemId;
            this.path = path;
        }
        public string Text
        {
            get { return text; }
        }
        public int ItemId
        {
            get { return itemId; }
        }
        public string Path
        {
            get { return path; }
        }
        public override bool Equals(object other)
        {
            Foo otherFoo = other as Foo;
            if (otherFoo == null)
            {
                return false;
            }
            return EqualityComparer<string>.Default.Equals(text, otherFoo.text) &&
            return EqualityComparer<int>.Default.Equals(itemId, otherFoo.itemId) &&
            return EqualityComparer<string>.Default.Equals(path, otherFoo.path);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + EqualityComparer<string>.Default.GetHashCode(text);
            hash = hash * 23 + EqualityComparer<int>.Default.GetHashCode(itemId);
            hash = hash * 23 + EqualityComparer<string>.Default.GetHashCode(path);
            return hash;
        }
    }
