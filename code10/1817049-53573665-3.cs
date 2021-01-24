    List<Entry> entries = new List<Entry>();
    
                entries.Add(new Entry("d1", "donation 1", new DateTime(2018, 11, 3), 10));
                entries.Add(new Entry("d2", "donation 2", new DateTime(2018, 11, 5), 90));
                entries.Add(new Entry("d3", "donation 3", new DateTime(2018, 11, 7), 100));
                entries.Add(new Entry("d4", "donation 4", new DateTime(2018, 11, 11), 30));
                entries.Add(new Entry("d5", "donation 5", new DateTime(2018, 11, 12), 20));
    
                List<Entry2> entries2 = new List<Entry2>();
                foreach(var e in entries) 
                {
                    entries2.Add(new Entry2(e.Reference, e.Donation, e.Date, e.Amount, NextSunday(e.Date)));
                }
    
                var list = from e in entries2
                           where e.Donation != "Gift Aid"
                           group e.Amount by e.Date2 into p
                           select new
                           {
                               Date2 = p.Key,
                               Amount = p.Sum()
                           };
    foreach(var p in list)
                {
                    Entry e = new Entry("Some code", "Gift Aid", p.Date2, p.Amount);
                    entries.Add(e);
                }
                var sortedentries = from e in entries
                                    orderby e.Date
                                    select e;
    
                foreach(var e in sortedentries)
                {
                    Console.WriteLine($"{e.Reference}; {e.Donation} occurred on {e.Date}; the amount is of {e.Amount} USD");
                }
