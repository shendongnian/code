            var fromDate=new DateTime(2016,12,1);
            var tillDate=new DateTime(2016,12,29);
            //I need to includ fromDate and tillDate in the calculation!
            var workingDays = Enumerable
                .Range(0, Convert.ToInt32(tillDate.Subtract(fromDate).TotalDays)+1)
                .Where(x => fromDate.AddDays(x).DayOfWeek != DayOfWeek.Saturday)
                .Where(x => fromDate.AddDays(x).DayOfWeek != DayOfWeek.Sunday)
                .Count();
