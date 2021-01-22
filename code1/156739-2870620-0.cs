    public abstract class A<T>
    { 
        public abstract T MethodB(string s); 
    } 
 
    public class C: A<DateTime> 
    { 
        public override DateTime MethodB(string s) 
        { 
            ...
        } 
    } 
