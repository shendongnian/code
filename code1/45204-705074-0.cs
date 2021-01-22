    abstract class Base {
         // ...
         protected Base(string commonField) {
            CommonField = commonField;
         }
    }
    class Derived1 : Base {
         public Derived1(string commonField, string specificField) : base(commonField) {
            SpecificField = specificField;
         }
    }
