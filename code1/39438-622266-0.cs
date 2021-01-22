    public class Foo<T> : 
       where T : Attribute
    {
        public string GetID(T something) { return something.TypeId; }
     // ..
    }
    
    Foo<DescriptionAttribute> bar; // OK, DescriptionAttribute inherits Attribute
    Foo<int> baz; // Compiler error, int does not inherit Attribute
