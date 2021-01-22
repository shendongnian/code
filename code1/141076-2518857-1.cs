        public class MyTestEntity
        {
            public string Str { get; set; }
            public int? Int { get; set; }
        }
    
    MyTestEntity test = new MyTestEntity();
    var empty = IsEmptyEntity(test); //returns true
