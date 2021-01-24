    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        private string _test = "Some constant value at this point";
        public string GetTest()
        {
            return _test;
        }
        public void SetTest()
        {
            //Nothing happens, you aren't allow to alter it. 
            //_test = "some constant 2";
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Test> listOfTest = new List<Test>()
            {
                new Test() {Id = 0, Name = "NumberOne", Amount = 1.0M},
                new Test() {Id = 1, Name = "NumberTwo", Amount = 2.0M}
            };
            Test target = listOfTest.First(x => x.Id == 0);
            Console.WriteLine(target.Name);
            target.Name = "NumberOneUpdated";
            Console.WriteLine(listOfTest.First(x => x.Id == 0).Name);
            Console.WriteLine(listOfTest.First(x => x.Id == 0).GetTest());//This will alsways be "Some constant value at this point";
            
            Console.ReadLine();
        }
    }
