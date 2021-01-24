    class Program
    {
        public class  MyClass
        {
            public string SomeValue { get; set; }
            public object Clone()
            {
                return MemberwiseClone();
            }
        }
        static void Main(string[] args)
        {
            LinkedList<MyClass> linkedList = new LinkedList<MyClass>();
            linkedList.AddLast(new MyClass() { SomeValue = "1" });
            linkedList.AddLast(new MyClass() { SomeValue = "2" });
            LinkedList<MyClass> copyLinkedList = new LinkedList<MyClass>(linkedList);
            MyClass temp = new MyClass(){SomeValue = "temp"};
            MyClass copyTemp = temp.Clone() as MyClass;
            temp.SomeValue = "Change Temp";
            linkedList.AddLast(temp);
            copyLinkedList.AddLast(copyTemp);
            foreach (MyClass myClass in linkedList)
            {
                Console.WriteLine(myClass.SomeValue);
            }
            Console.WriteLine("--------------");
            foreach (MyClass myClass in copyLinkedList)
            {
                Console.WriteLine(myClass.SomeValue);
            }
            Console.ReadKey();
        }
    }
