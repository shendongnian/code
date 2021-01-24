    List<Entry> entries = new List<Entry>();
    
                entries.Add(new Entry(1, "donation 1", new DateTime(2018, 11, 3), 10));
                entries.Add(new Entry(1, "donation 2", new DateTime(2018, 11, 5), 90));
                entries.Add(new Entry(1, "donation 3", new DateTime(2018, 11, 7), 100));
                entries.Add(new Entry(2, "donation 4", new DateTime(2018, 11, 11), 30));
                entries.Add(new Entry(2, "donation 5", new DateTime(2018, 11, 12), 20));
    
                var list = from e in entries
                           where e.Donation != "partial total"
                           group e.Amount by e.Reference into p
                           select new
                           {
                               Reference = p.Key,
                               Amount = p.Sum()
                           };
    
                var listjoined = from p in list
                                 join e in entries on p.Reference equals e.Reference
                                 group e.Date by p into a
                                 select new
                                 {
                                     Reference = a.Key.Reference,
                                     Amount = a.Key.Amount,
                                     Date = a.Max()
                                 };
    
    
                foreach(var p in listjoined)
                {
                    Entry e = new Entry(p.Reference, "partial total", p.Date, p.Amount);
                    entries.Add(e);
                }
                var sortedentries = from e in entries
                                    orderby e.Reference, e.Date
                                    select e;
    
                foreach(var e in sortedentries)
                {
                    Console.WriteLine($"{e.Reference}; {e.Donation} occurred on {e.Date}; the amount is of {e.Amount} USD");
                }
