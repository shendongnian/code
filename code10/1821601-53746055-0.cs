    public class Program
    {
        public static void Main(string[] args)
        {
            List<data> myList = new List<data>();
            myList.Add(new data("output1", "1,5"));
            myList.Add(new data("output2", "1,6"));
            myList.Add(new data("output1", "1,5"));
            myList.Add(new data("output1", "2,0"));
            
            ILookup<string, string> myLookup = myList.ToLookup(d => d.output, d => d.input);
            
            foreach (IGrouping<string, string> items in myLookup)
            {
                Console.WriteLine("Output : " + items.Key);
                foreach (string input in items)
                {
                    Console.WriteLine("-- Input value is " + input);
                }
            }
        }
    }
    
    public class data
    {
        public string output;
        public string input;
        
        public data(string output, string input)
        {
            this.output = output;
            this.input = input;
        }
    }
