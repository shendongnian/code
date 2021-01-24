    var data = new List<DateTime>
                {
                    new DateTime(2012, 02, 19, 10, 06, 29, 287), new DateTime(2012, 02, 19, 10, 06, 29, 900) ,
                    new DateTime(2014, 01, 21, 15, 21, 11, 114) ,
                    new DateTime(2015, 04, 22, 01, 11, 50, 233),
                    new DateTime(2015, 04, 22, 01, 11, 55, 921),
                    new DateTime(2015, 04, 22, 01, 12, 12, 144),
                    new DateTime(2017, 12, 18, 12, 01, 01, 762)
                };
    
                var dataFIltered = data.Select(c => new DateTime(c.Year,c.Month,c.Minute)).Distinct().ToList();
