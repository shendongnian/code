    public class Program
    {
    	public static void Main()
    	{
    		 var sabtReqID = 0;
    
                var myCase = ReflectiveEnumerator.GetEnumerableOfType<Case>().FirstOrDefault(c => c.Id == sabtReqID);
                if (myCase != null)
                {
                    myCase.Todo();
                }
            }
    
            public static class ReflectiveEnumerator
            {
                static ReflectiveEnumerator() { }
    
                public static IEnumerable<T> GetEnumerableOfType<T>() where T : class
                {
                    List<T> objects = new List<T>();
                    foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes()
                        .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
                    {
                        objects.Add((T)Activator.CreateInstance(type));
                    }
                    return objects;
                }
            }
        }
    
    
    public abstract class Case
    {
        public abstract void Todo();
    
        public virtual int Id { get; }
    }
    
    public class NameCase : Case
    {
        public override int Id => 0;
        public override void Todo()
        {
            Console.WriteLine("NameCase Hello World");
        }
    }
    
    public class FatherNameCase : Case
    {
        public override int Id => 1;
        public override void Todo()
        {
            Console.WriteLine("FatherNameCase Hello World");
        }
    }
