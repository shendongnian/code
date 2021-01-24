    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Id());
            Console.ReadLine();
        }
    
        static private string Id()
        {    
            var dateTimeNow = DateTime.Now;
            return string.Format("{0} {1:yy} {2:D3} {1:hh} {1:mm} 0{1:ss}", 
               "AB", dateTimeNow, dateTimeNow.DayOfYear);
        }
    }
