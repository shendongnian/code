    public class BaseClass<T> {
        public static T Find(object value){
             -- db.get<T>("params", value);
        }
    }
    
    public class Derived: BaseClass<Derived> {
    
        void someMethod(){
          Derived obj = Derived.Find(1);
        }
    }
