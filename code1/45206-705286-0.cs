    abstract class Base {
         protected ParsedData ParsedData;
         // ...
         protected Base(string x) {
            ParsedData = Parse(x);
            CommonFields(); //initialize common fields using ParsedData
         }
    }
    
    class Derived1 : Base {
         public Derived1(string x) : base(x) {
            DerivedFields(); //initialize specific fields using ParsedData
         }
    }
