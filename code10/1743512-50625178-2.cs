    public class Book
    {
        public List<Sheet> Sheets { get; set; }
    }
    
    public abstract class Sheet
    {
        public string Name { get; set; }
        public abstract IList Data { get; }
    }
    
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
