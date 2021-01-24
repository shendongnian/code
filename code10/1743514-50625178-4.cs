    public class Book
    {
        public List<Sheet> Sheets { get; set; }
    }
    
    //Use sheet as a base class for specific Sheet
    public abstract class Sheet
    {
        public string Name { get; set; }
        public abstract IList Data { get; }
    }
    
    //Use the generic class to unify sheet management
    public class SheetTyped<T> : Sheet
    {        
        private List<T> _data { get; set; }
        public override IList Data { get { return _data; } }
        public SheetTyped(string sheetName, List<T> lData)
        {
            _data = lData;
            Name = sheetName;
        }
    }
