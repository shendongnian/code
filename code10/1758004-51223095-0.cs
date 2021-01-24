    public class Program
    {
        public static void Main(string[] args)
        {
            var data = new List<string>() { "bill", "david", "john", "daviddd" };
    
            var stringsStartingWithD = data.Where (s => StarstWithD(s)).ToList();
    
            var anotherOne = data.Where (s => SomeOtherTest(s)).ToList();
        }
    
        public static bool StarstWithD(string str)
        {
            if (str.StartsWith("d"))
            {
                return true;
            }
            return false;
        }     
    
        public static bool SomeOtherTest(string str)
        {
            bool result = false;
            // apply desired logic and return true/false
            //...
    
            return result;
        } 
