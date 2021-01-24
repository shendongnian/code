    class PageBase
    {
        public string Id { get; set; }
        public string ClassName { get; set; }
        public string Text { get; set; }
        public string PartialText { get; set; }
        public string XPath { get; set; }
        public string CssModifier { get; set; }
    }
    class SearchOptions : PageBase
    {
        public SearchOptions()
        {
            Id = string.Empty;
            ClassName = string.Empty;
            Text = string.Empty;
            PartialText = string.Empty;
            XPath = string.Empty;
            CssModifier = string.Empty;
        }
        public string JustAFunction()
        {
            Console.WriteLine(Id);
            Console.WriteLine(ClassName);
            return "ImportantReturn";
        }
    }
