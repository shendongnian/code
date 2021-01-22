    abstract class Base {
         protected ParsedData ParsedData;
         // ...
         public static ParsedData Parse(string x)
         {
            //Parse x here...
         }
         
         protected Base(ParsedData data) {
            CommonFields(data); //initialize common fields using data
         }
    }
    
    class Derived1 : Base {
         public Derived1(ParsedData data) : base(data) {
            DerivedFields(data); //initialize specific fields using data
         }
    }
