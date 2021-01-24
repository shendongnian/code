    class Program
    {
        static void Main(string[] args)
        {
            var specialList = new List<C>();
            specialList.AddRange(listA.Where(x => ListB.Where(c => c.Name == x.Name).Any()).Select(x => new C()
            {
                Name = x.Name
            }));
        }
    }
    public class A
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
    public class B
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
    }
    public class C
    {
        public string Name { get; set; }
    }
