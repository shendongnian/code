    public class DataReader
    {
        public enum Type
        {
            Sql,
            Oracle,
            OleDb
        }
    
        public Type Type { get; set; } // <===== Won't compile =====
    
    }
