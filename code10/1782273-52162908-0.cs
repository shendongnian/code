        public class FirstClass
        {
            public Field Field1 { get; set; }
            public Field Field2 { get; set; }
            public Field Field3 { get; set; }
            public Field Field4 { get; set; }
            public Field Field5 { get; set; }
            public IEnumerable<Field> AllFields => 
                   new [] { Field1, Field2, Field3, Field4, Field 5 };
        }
