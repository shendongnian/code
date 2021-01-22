        public class MyObject
    {
        public int SimpleInt { get; set; }
    }
    class Program
    {
        public static void RunChangeList()
        {
            var objs = new List<MyObject>() { new MyObject() { SimpleInt = 0 } };
            Console.WriteLine("objs: {0}", objs.GetHashCode());
            Console.WriteLine("objs[0]: {0}", objs[0].GetHashCode());
            var whatInt = ChangeToList(objs);
            Console.WriteLine("whatInt: {0}", whatInt.GetHashCode());
        }
        public static int ChangeToList(List<MyObject> objects)
        {
            Console.WriteLine("objects: {0}", objects.GetHashCode());
            Console.WriteLine("objects[0]: {0}", objects[0].GetHashCode());
            var objectList = objects.ToList();
            Console.WriteLine("objectList: {0}", objectList.GetHashCode());
            Console.WriteLine("objectList[0]: {0}", objectList[0].GetHashCode());
            objectList[0].SimpleInt = 5;
            return objects[0].SimpleInt;
        }
        private static void Main(string[] args)
        {
            RunChangeList();
            Console.ReadLine();
        }
