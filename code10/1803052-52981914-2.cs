        private static void Main(string[] args)
        {
            const string DATE_FORMAT = "MM/dd/yyyy hh:mm:ss tt";
            Console.WriteLine(DateTime.Now.ToString(DATE_FORMAT, CultureInfo.InvariantCulture));
            string dateText = "10/25/2018 10:38:26 AM";
            var op = DateTime.ParseExact(dateText, DATE_FORMAT, CultureInfo.InvariantCulture);
            Console.WriteLine(op.ToString(DATE_FORMAT,CultureInfo.InvariantCulture));
            Console.ReadKey();
        }
    
        
