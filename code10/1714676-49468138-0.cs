    public class Test
    {
        public string Name { set; get; }
        public string Address { set; get; }
    
        public override string ToString()
        {
            return $"Name: {Name} Address: {Address}";
        }
    }
    
    static void Main(string[] args)
    {
        Test t = new Test();
    
        t.Name = "bob";
        t.Address = "CT";
    
        List<Test> lst = new List<Test>();
    
        lst.Add(t);
    
        foreach (var x in lst)
        {
            Console.WriteLine(x);
        }
    }
