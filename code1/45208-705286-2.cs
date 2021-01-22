    abstract class Base {
         // ...
         protected Base(string x) {
            var data = Parse(x);
            CommonFields(data); //initialize common fields using data
         }
    }
    
    class Derived1 : Base {
         public Derived1(string x) : base(x) {
            var data = Parse(x);
            DerivedFields(data); //initialize specific fields using data
         }
    }
