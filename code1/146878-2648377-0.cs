    interface IHeaderRow
    {
        string GetText();
    }
    class HeaderRow : IHeaderRow
    {
        public string GetText()
        { 
            return "My Label";
        }
        public int GetFoo()
        {
            return 42;
        }
    }
    class ObjectRawRow : IHeaderRow
    {
        public string GetText()
        {
            return "My Raw Label";
        }
    }
