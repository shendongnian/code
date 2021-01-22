    public class MyTypes
    {
        public MyType this[string name]
        {
            get {
                switch(name) {
                     case "Type1":
                          return new MyType("Type1");
                     case "Type2":
                          return new MySubType();
                // ...
                }
            }
        }
    }
