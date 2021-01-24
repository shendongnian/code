    public class SimpleSet
    {
        public string name { get; set; }
        public int id { get; set; }
        public SimpleSet(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    public void Execute()
    {
        string[] input = new string[] { "A", "B", "C" };
        //string[] dataset = new string[] { "A", "B", "C", "D", "E" };
    
        List<SimpleSet> dataset = new List<SimpleSet>();
        dataset.Add(new SimpleSet(1, "A"));
        dataset.Add(new SimpleSet(2, "B"));
        dataset.Add(new SimpleSet(3, "C"));
        dataset.Add(new SimpleSet(4, "D"));
        dataset.Add(new SimpleSet(5, "E"));
    
        List<SimpleSet> output = dataset.Where(x => input.Contains(x.name)).ToList();
        List<string> output_namesOnly = dataset.Where(x => input.Contains(x.name)).Select(x => x.name).ToList();
        List<int> output_idsOnly = dataset.Where(x => input.Contains(x.name)).Select(x => x.id).ToList();
    }
