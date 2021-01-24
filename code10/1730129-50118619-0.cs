    class Program
        {
            static void Main(string[] args)
            {
               
                DateTime date = new DateTime(2018,04,04);
                DateTime dateandTime = new DateTime(date.Year,date.Month,date.Day , 16,00,00);
    
                Console.WriteLine(dateandTime);
              
                Console.ReadLine();
            }
        }
