    public class Book
    {
        public List<Sheet> Sheets { get; set; }
    }
    
    //Use sheet a base class for specific Sheet
    public abstract class Sheet
    {
        public string Name { get; set; }
        public IList  Data { get; set; }
    }
    
    //Use the generic class to unify sheet management
    public class SheetTyped<T> : Sheet
    {
        public string   Name { get; set; }
        public List<T>  Data { get; set; }
        
        //Creator
        public void SheetTyped<T>( string sheetName, List<T> lData )
        {
            Data = lData ;
            Name = sheetName ;
        }
    }
