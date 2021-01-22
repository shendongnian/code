    public class MyOwnAttributeClass : Attribute {
        public MyOwnAttributeClass() {
        }
        public MyOwnAttributeClass(string myName) {
            MyName = myName;
        }
        public string MyName { get; set; }
    }
