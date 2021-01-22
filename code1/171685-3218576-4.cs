    public class Tag : IEquatable<Tag>
    {
        public Tag(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
    
        public bool Equals(Tag other)
        {
            return other != null && string.Equals(Text, other.Text);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Tag);
        }
        public override int GetHashCode()
        {
            return (Text ?? string.Empty).GetHashCode();
        }
    }
