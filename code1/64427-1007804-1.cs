    public class MyClass
    {
            public int PO { get; set; }
            public String SKU { get; set; }
            public int Qty { get; set; }
            public static IEnumerable<MyClass> GetList()
            {
                return new List<MyClass>()
                           {
                               new MyClass {PO = 1, SKU = "ABC", Qty = 1},
                               new MyClass {PO = 1, SKU = "DEF", Qty = 2},
                               new MyClass {PO = 1, SKU = "GHI", Qty = 1},
                               new MyClass {PO = 1, SKU = "QWE", Qty = 1},
                               new MyClass {PO = 1, SKU = "ASD", Qty = 1},
                               new MyClass {PO = 1, SKU = "ZXC", Qty = 5},
                               new MyClass {PO = 1, SKU = "ERT", Qty = 1},
                               new MyClass {PO = 2, SKU = "QWE", Qty = 1},
                               new MyClass {PO = 2, SKU = "ASD", Qty = 1},
                               new MyClass {PO = 2, SKU = "ZXC", Qty = 5},
                           };
            }
     }
