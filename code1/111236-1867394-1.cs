    using System;
    using System.Reflection;
    
    namespace ConsoleApplication14
    {
        public class Program
        {
            static void Main(string[] args)
            {
                Dummy d = new Dummy();
                EntityType e = new EntityType();
                d.Delete(e);
    
                Console.In.ReadLine();
            }
        }
    
        public class EntityType
        {
            public EntityType()
            {
            }
        }
    
        public class Dummy
        {
            private Repository<EntityType> _repo = new Repository<EntityType>();
    
            public void Delete(object toDelete)
            {
                Type t = _repo.GetType();
                Type genericType = t.GetGenericArguments()[0];
                MethodInfo mi = t.GetMethod("Delete",
                    BindingFlags.Public | BindingFlags.Instance,
                    null, new Type[] { genericType }, new ParameterModifier[0]);
                // _repo.Delete(toDelete);
                mi.Invoke(_repo, new Object[] { toDelete });
            }
        }
    
        public class Repository<T>
            where T: class, new()
        {
            public void Delete(T value)
            {
                Console.Out.WriteLine("deleted: " + value);
            }
        }
    }
