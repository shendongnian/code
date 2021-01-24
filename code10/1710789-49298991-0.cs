            List<DateTime> latesApproved = new List<DateTime>
            {
                Convert.ToDateTime("01/03/2018 12:00:00"),
                Convert.ToDateTime("05/03/2018 12:00:00"),
                Convert.ToDateTime("09/03/2018 12:00:00"),
                Convert.ToDateTime("13/03/2018 12:00:00")
            };
            List<DateTime> lateComings = new List<DateTime>
            {
                Convert.ToDateTime("05/03/2018 11:00:32"),
                Convert.ToDateTime("06/03/2018 10:54:33"),
                Convert.ToDateTime("07/03/2018 08:34:47"),
                Convert.ToDateTime("08/03/2018 12:30:40"),
                Convert.ToDateTime("09/03/2018 10:03:00"),
                Convert.ToDateTime("10/03/2018 11:03:00"),
                Convert.ToDateTime("11/03/2018 11:30:40"),
                Convert.ToDateTime("12/03/2018 10:30:40"),
                Convert.ToDateTime("13/03/2018 08:30:00")
            };
            List<DateTime> dateTimes = lateComings
                .Where(x => !latesApproved
                    .Select(a => a.Date)
                    .Contains(x.Date))
                .ToList();
