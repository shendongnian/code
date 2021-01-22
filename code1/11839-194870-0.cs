        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            Random gen = new Random();
            int range = ((TimeSpan)(DateTime.Now - start)).Days;           
            return start.AddDays(gen.Next(range);
        }
For better performance if this will be called repeatedly, create the start and gen variables _outside_ of the function.
