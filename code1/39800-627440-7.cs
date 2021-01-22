    public class Program
    {
        public static void DescribeAnimal(IAnimal animal)
        {
            Console.WriteLine("My name is {0}, I am a {1}", animal.WhatIsMyName, animal.WhatAmI);
        }
        static void Main(string[] args)
        {
            Dog mydog = new Dog("Spot");
            Cat mycat = new Cat("Felix");
            DescribeAnimal(mydog);
            DescribeAnimal(mycat);
            Console.ReadKey();
        }
    }
