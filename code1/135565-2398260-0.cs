    public class Foo
    {
        private string bar;
        public string Bar
        {
            get { return HttpUtility.HtmlDecode(bar); }
            set { bar = HttpUtility.HtmlEncode(value); }
        }
        public string SafeBar
        {
            get { return bar; }
        }
    }
