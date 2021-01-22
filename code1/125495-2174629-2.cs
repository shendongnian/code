    public class BaseRecord {  
        public bool isDirty;  
        public object [] itemArray;  
    }
    
    public class PeopleRec : BaseRecord {  
        class Columns {
            public static const string FirstName =  "FIRST_NAME";
            public static const string LastName = "LAST_NAME";
        }
    }
    
    public class OrderRec : BaseRecord {  
        class Columns {
            public static const string OrderId =  "ORDER_ID";
            public static const string Line = "LINE";
            public static const string PartNo = "PART_NO";
            public static const string Qty = "QTY";
        }
    }
