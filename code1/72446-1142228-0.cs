      Type t = typeof(MyClass);
                List<Type> Gtypes = new List<Type>();
                foreach (Type it in t.GetInterfaces())
                {
                    if ( it.IsGenericType && it.GetGenericTypeDefinition() == typeof(IGeneric<>))
                        Gtypes.AddRange(it.GetGenericArguments());
                }
    
     public class MyClass : IGeneric<Employee>, IGeneric<Company>, IDontWantThis<EvilType> { }
        
        public interface IGeneric<T>{}
        public interface IDontWantThis<T>{}
        public class Employee{ }
    
        public class Company{ }
    
        public class EvilType{ }
