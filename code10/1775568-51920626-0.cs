        public class SpreadsheetRow
        {
        public string ClassAProp1 { get; set; }
        public string ClassAProp2 { get; set; }
        public string ClassAProp3 { get; set; }
        public string ClassBProp1 { get; set; }
        public string ClassBProp2 { get; set; }
        public string ClassBProp3 { get; set; }
        public string ClassCProp1 { get; set; }
        public string ClassCProp2 { get; set; }
        public string ClassCProp3 { get; set; }
        public ClassA GetClassA()
        {
            return new ClassA
            {
                Prop1 = ClassAProp1,
                Prop2 = ClassAProp2,
                Prop3 = ClassAProp3,
            };
        }
        public ClassB GetClassB()
        {
            return new ClassB
            {
                Prop1 = ClassBProp1,
                Prop2 = ClassBProp2,
                Prop3 = ClassBProp3,
                Nested = new ClassC
                {
                    Prop1 = ClassCProp1,
                    Prop2 = ClassCProp2,
                    Prop3 = ClassCProp3,
                }
            };
        }
    }
