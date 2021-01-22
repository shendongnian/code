    public class Examples
    {
        public void Tests()
        {
            if (1278677571.IsYesterday()) System.Console.WriteLine("Is yesterday");
            DateTime aDate = new DateTime(2010, 12, 31);
            if (aDate.IsYesterday()) System.Console.WriteLine("Is yesterday");
        }
    }
