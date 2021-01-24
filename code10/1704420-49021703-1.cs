    static class Ext
    {
        public static void FindElement(List<string> test)
        {
            test.Add("blah");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>> dell = Ext.FindElement;
            var control = new List<string>();
            dell(control);// calling the extension method via the assigned delegate
        }
    }
