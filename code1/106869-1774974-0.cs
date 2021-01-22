    public class Runner
    {
        public static void Main()
        {
            var myList = new List<Concrete>();
            DoStuffWithInterfaceList(myList);  // compiler doesn't allow this
        }
    
        public static void DoStuffWithInterfaceList<T>(List<T> listOfInterfaces)
            where T: IConcrete
        { }
    }
