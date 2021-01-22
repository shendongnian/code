    public interface IFormatter
    {
        string Format();
    }
    public class HtmlFormatter: IFormatter
    {
        public Format()
        {
            return ...string translated to HTML...
        }
    }
    public class PlainTextFormatter : IFormatter
    {
        public Format()
        {
            ...go through and remove all markdown and return rest
        }
    }
    public class Post : IFormattable
    {
        public IFormatter Formatter { get; set; }
        public Post( IFormatter formatter )
        {
            this.Formatter = formatter ?? new HtmlFormatter();
        }
        public Format()
        {
            return this.Formatter.Format();
        }
    }
