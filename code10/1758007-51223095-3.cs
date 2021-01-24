    public class Program
    {
        public static void Main(string[] args)
        {
            var data = new List<string>() { "bill", "david", "john", "daviddd" };
            var stringsStartingWithD = data.Where (s => s.StartsWith("d")).ToList();    
        }
