    public class ErrorType
    {
        List<ErrorType> _childErrors;
    
        public String Name { get; set; }
        public bool Ignore { get; set; }
    
        public List<ErrorType> ChildErrors { get; protected set; }
        public static ErrorType Parse(XElement element)
        {
            return new ErrorType
            {
                Name = element.Name.LocalName;
                Ignore = (bool) element.Attribute("ignore"),
                ChildErrors = element.Elements()
                                     .Select(Parse)
                                     .ToList();
            };
        }
    }
    public class ErrorList
    {
        public List<ErrorType> ChildErrors { get; protected set; }
        public static ErrorList Parse(XElement element)
        {
            return new ErrorList(ChildErrors = element.Elements()
                                     .Select(x => ErrorType.Parse(x))
                                     .ToList());
        }
    }
