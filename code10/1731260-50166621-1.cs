    public static void CalculateDistDates()
        {            
            var drivers = new List<Drivers>
            {
                new Drivers{Journey = new Journey {Distance = 1.2M, JourneyDate = DateTime.Now.AddDays(1).Date}},
                new Drivers{Journey =  new Journey{Distance = 1.2M, JourneyDate = DateTime.Now.AddDays(2).Date}},
                new Drivers{Journey =  new Journey{Distance = 1.1M, JourneyDate = DateTime.Now.AddDays(2).Date}},
                new Drivers{Journey =  new Journey{Distance = 1.5M, JourneyDate = DateTime.Now.AddDays(3).Date}},
                new Drivers{Journey = new Journey {Distance = 1.7M, JourneyDate = DateTime.Now.AddDays(-1).Date}},
                new Drivers{Journey =  new Journey{Distance = 1.1M, JourneyDate = DateTime.Now.AddDays(3).Date}},
                new Drivers{Journey =  new Journey{Distance = 0.2M, JourneyDate = DateTime.Now.AddDays(2).Date}}
            };
            var totalDistance = (from d in drivers
                group d by d.Journey.JourneyDate
                into j                 
                select new DistanceCovered
                {
                    JourneyDate = j.Key,
                    TotalDistance = j.Sum(r=>r.Journey.Distance)
                }).ToList().OrderBy(r=>r.JourneyDate).ThenByDescending(r=>r.TotalDistance);
            foreach (var t in totalDistance)
            {
                Console.WriteLine($"{t.JourneyDate}: {t.TotalDistance}" );
            }
            Console.ReadLine();            
        }
