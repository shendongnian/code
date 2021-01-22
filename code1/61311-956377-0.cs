    public class List1
    {
        public int ID { get; set; }
        public string Person { get; set; }
    }
    public class List2
    {
        public int ID { get; set; }
        public int Value { get; set; }
    }
    var lList1 = new List<List1>
                 {
                    new List1 {ID = 1, Person = "Alice"},
                    new List1 {ID = 2, Person = "Bob"},
                    new List1 {ID = 3, Person = "Carol"},
                    new List1 {ID = 4, Person = "Dave"}
                 };
    var lList2 = new List<List2>
                 {
                   new List2 {ID = 1, Value = 15},
                   new List2 {ID = 1, Value = 19},
                   new List2 {ID = 2, Value = 5},
                   new List2 {ID = 2, Value = 7},
                   new List2 {ID = 2, Value = 20},
                   new List2 {ID = 4, Value = 16}
                 };
    var lOutput = lList1.SelectMany(pArg => 
                                 lList2.Where(pArg1 => pArg1.ID == pArg.ID)
                                       .DefaultIfEmpty(new List2 { ID = pArg.ID, Value = 0})
                                       .Select(pArg1 => pArg1));
