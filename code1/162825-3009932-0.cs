    public class ClassA<T> where T : BaseClass 
    { 
        public T MyClass { get; set; } 
     
        public ClassA(T myClass) { MyClass = myClass; } 
    
        public void DoStuffToMyClass()
        {
            if(MyClass is BaseClass) 
            { // do base class stuff }
            else if(Myclass is DerivedClass)
            { // do DerivedClass stuff }
            else if(MyClass is DerivedClass2)
            { // do DerivedClass2 stuff }
        }
    }
