    var inputDates = new List<DateTime>
                    {                
                        DateTime.Parse("2018 - 05-07 18:31:57"),
                        DateTime.Parse("2018 - 05 - 07 18:27:02"),
                        DateTime.Parse("2018 - 05 - 07 18:26:19"),
                        DateTime.Parse("2018 - 05 - 07 18:23:44")
                    };
       var inputDateTime = DateTime.Parse("2018 - 05 - 07 18:32:00");
       var date = inputDates.Where(d => d < inputDateTime).OrderByDescending(r => r.Ticks).FirstOrDefault();
