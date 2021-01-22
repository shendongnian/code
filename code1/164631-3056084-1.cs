    namespace MyApplication
    {
        public class MyResultObject
        {
            public Display.OrderCost Display { get; set; }
    
            public IList<Data.OrderCost> Data { get; set; }
        }
    }
    
    namespace MyApplication.Display
    {
        public class Column
        {
            public string HeaderText { get; set; }
            public bool Visible { get; set; }
        }
    
        public class OrderCost
        {
            public Column OrderNum { get; set; }
            public Column OrderLine { get; set; }
            public Column OrderRel { get; set; }
            public Column OrderDate { get; set; }
            public Column PartNum { get; set; }
            public Column Description { get; set; }
            public Column Qty { get; set; }
            public Column SalesUM { get; set; }
            public Column Cost { get; set; }
            public Column Price { get; set; }
            public Column Net { get; set; }
            public Column Margin { get; set; }
            public Column EntryPerson { get; set; }
            public Column CustID { get; set; }
            public Column Customer { get; set; }
        }
    }
    
    namespace MyApplication.Data
    {
        public class OrderCost
        {
            public int OrderNum { get; set; }
            public int OrderLine { get; set; }
            public int OrderRel { get; set; }
            public DateTime OrderDate { get; set; }
            public string PartNum { get; set; }
            public string Description { get; set; }
            public decimal Qty { get; set; }
            public string SalesUM { get; set; }
            public decimal Cost { get; set; }
            public decimal Price { get; set; }
            public decimal Net { get; set; }
            public decimal Margin { get; set; }
            public string EntryPerson { get; set; }
            public string CustID { get; set; }
            public string Customer { get; set; }
        }
    }
