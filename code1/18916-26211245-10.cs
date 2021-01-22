    pubic class DataTable
    {
        public class Rows
        {       
           private string _count;        
           // This Count will be accessable to us but have used only "get" ie, readonly
           public int Count
           {
               get
               {
                  return _count;
               }       
           }
        } 
        public class Columns
        {
            private string _caption;        
  
            // Used both "get" and "set" ie, readable and writable
            public string Caption
            {
               get
               {
                  return _caption;
               }
               set
               {
                  _caption = value;
               }
           }       
        } 
    }
