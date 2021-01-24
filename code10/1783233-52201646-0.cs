    public abstract class Common
    {
        public string CommonString { get; set; }
    }
    public class B : Common
    {
    }
    public class A : Common
    {
    }
    public class ABConsumer
    {
        public void DoSomething(List<Common> myList)
        {
            List<Common> EmptyStrings = myList.Where(x => x.CommonString == string.Empty).ToList();
        }
    }
