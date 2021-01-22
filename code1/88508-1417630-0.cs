    public class A {
       private static A _instance;
       private static object _lk = new object();
       public static A Instance() {
           try {
               return _instance.Self();
           } catch(NullReferenceExceptio) {
               lock(_lk) {
                   if (_instance == null)
                       _instance = new A();
               }
           }           
           return _instance.Self();
       }
       private A Self() {
           return this;
       }
    }
