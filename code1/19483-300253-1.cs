     public abstract class MyBase
     {
        public static T GetNewDerived<T>() where T : MyBase, new()
        {
            return new T();
        }    
     }
     public class DerivedA : MyBase
     {
        public static DerivedA GetNewDerived()
        {
            return GetNewDerived<DerivedA>();
        }
     }
    
     public class DerivedB : MyBase
     {
        public static DerivedB GetNewDerived()
        {
            return GetNewDerived<DerivedB>();
        }
     }     
