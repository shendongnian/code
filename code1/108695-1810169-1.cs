    public class Test {
        public string Name { get; set; }
        public int Number { get; set; }
    }
    Test test = new Test() { Name = "Jenny", Number = "8675309" };
    Console.WriteLine(test.GetPropValue<string>("Name"));
    Console.WriteLine(test.GetPropValue<int>("Number"));
