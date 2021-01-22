        static void Main(string[] args)
        {
            ClosestDate obj = new ClosestDate();
            List<DateTime> pricesList = new List<DateTime>();
            pricesList.Add(DateTime.ParseExact("01/03/2011", "dd/MM/yyyy", null));
            pricesList.Add(DateTime.ParseExact("05/03/2011", "dd/MM/yyyy", null));
            pricesList.Add(DateTime.ParseExact("01/05/2011", "dd/MM/yyyy", null));
            pricesList.Add(DateTime.ParseExact("02/06/2011", "dd/MM/yyyy", null));
            obj.GetClosestDate(DateTime.ParseExact("01/04/2011", "dd/MM/yyyy", null), pricesList, 4);
            Console.ReadLine();
        }
    }
