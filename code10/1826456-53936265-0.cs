    public class Program
    {
        private static List<string> lines;
	    public static void Main()
	    {
            // At this point lines will have the entire file. Each line in a different index in the list
            lines = File.ReadAllLines("..path to file").ToList();
            
            useList(); // Use it however
        }
        // Just use the List which has the same data as the file
        public string readFromList(int num)
        {
            return lines[num];
        } 
        public static void useList()
        {
            string line1 = readFromList(1); // Could even be string line1 = lines[SomeNum];
            string line2 = readFromList(2);
        }
    }
