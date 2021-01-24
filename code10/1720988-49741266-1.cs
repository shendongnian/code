        public static void Main(string[] args)
        {
            var currentDate   = DateTime.UtcNow;
            var daysInMonth   = DateTime.DaysInMonth;
            var repeats       = 2;
            for(var i = 0; i < daysInMonth;i++)
            {
                foreach(var item in List)
                {
                    for(var r = 0; r < repeats;r++)
                    {
                        var client = new Client
                        {
                            Name = item.Name,
                            Date = currentDate.AddDays(i)
                        };
                        List2.Add(client);
                    }
                }
            }
        }
