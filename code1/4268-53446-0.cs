    class Program
    {
        static void Main(string[] args)
        {
            MyObjectsA testA = new MyObjectsA();
            testA.ToList().Add(new OtherObjectA());
            foreach (OtherObjectA a in testA.ToList())
            {
                System.Diagnostics.Debug.Print(a.Property);
            }
        }
    }
    public interface IOtherObjects
	{
        string Property { get; }
	}
    public class OtherObjectA : IOtherObjects
    {
        public string Property
        {
            get { return "I am an OtherObjectA"; } 
        }
    }
    public class OtherObjectB : IOtherObjects
    {
        public string Property
        {
            get { return "I am an OtherObjectB"; } 
        }
    }
    public abstract class MyObjects<T> where T : IOtherObjects
    {
        List<T> _objects = new List<T>();
        public List<T> ToList()
        {
            return _objects;
        }
    }
    public class MyObjectsA : MyObjects<OtherObjectA>
    {
    }
    public class MyObjectsB : MyObjects<OtherObjectB>
    {
    }
