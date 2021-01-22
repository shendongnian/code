    class Program
    {
        static void Main(string[] args)
        {
            var slist = new ScheduleSelectedItemsList() 
            { 
                new ScheduleSelectedItem("Yusuf") 
            };
            //write every item to the console, not just the first
            slist.All(item => Console.Write(item.ToString()) );
            Console.ReadKey();
        }
    }
