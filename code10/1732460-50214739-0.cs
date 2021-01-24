    var inputDates = new List<DateTime>
                    {                
                        new DateTime(2018, 5, 7, 18, 27, 02),
                        new DateTime(2018, 5, 7, 18, 26, 19),
                        new DateTime(2018, 5, 7, 18, 31, 57),
                        new DateTime(2018, 5, 7, 18, 23, 44),
                    };
       var inputDate = new DateTime(2018, 5, 7, 18, 32, 0);
       var date = inputDates.Where(d => d < inputDate).OrderByDescending(r => r.Ticks).FirstOrDefault();
