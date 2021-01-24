        public class Person
        {
            public int Pers_Id { get; set; }
            public string Pers_First_Name { get; set; }
            public string Pers_Last_Name { get; set; }
            public DateTime Pers_Update { get; set; }
            public List<Order> Order_List { get; set; }
            public class Order
            {
                public int OrderID { get; set; }
                public int OrderNu { get; set; }
            }
        }
        //You need a class that fits to your DataTable
        public class PersonDataTable
        {
            public int Pers_Id { get; set; }
            public string Pers_First_Name { get; set; }
            public string Pers_Last_Name { get; set; }
            public DateTime Pers_Update { get; set; }
            public int OrderId { get; set; }
            public int OrderNu { get; set; }
        }
    
    
