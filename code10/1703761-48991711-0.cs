    class Item
    {
        public int Value { get; set; }
        static int id = 0;
        public int Id { get; } = id++; // generate next id every time
    }
    static void Main(string[] args)
    {
        var range = new int[] { 1, 2, 3 }
            .Select(i => new Item { Value = i });
        foreach (var item in range)
        {
            Console.WriteLine(item.Value + "- id:" + item.Id);
            // Will output 
            //1- id:0
            //2- id:1
            //3- id:2
        }
        foreach (var item in range)
        {
            Console.WriteLine(item.Value + "- id:" + item.Id);
            // Will output 
            //1- id:3
            //2- id:4
            //3- id:5
        }
    }
