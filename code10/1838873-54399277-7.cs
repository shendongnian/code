    public class MyClass
    {
        public MyClass(string filename)
        {
            // initialize the fields according to the filename (for example:)
            int typeLength = 3;
            int indexOpen = filename.IndexOf("(");
            int indexClose = filename.IndexOf(")");
            Type = filename.Substring(0,typeLength);
            int.TryParse(filename.Substring(typeLength,indexOpen-typeLength),out Order);
            int.TryParse(filename.Substring(indexOpen+3, indexClose-indexOpen-2),out SCOrder);
        }
    
        public string Type {get;set;}
        public int Order {get;set;}
        public int SCOrder {get;set;}
    }
