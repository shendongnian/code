    DateTime today = Convert.ToDateTime("20.02.2018");
            DateTime start = Convert.ToDateTime("01.01.2018");
            DateTime End = Convert.ToDateTime("01.04.2018");
            TimeSpan diff = (End - start);
            double nrofdays = diff.TotalDays;
            double percentage = (((today) - (start)).TotalDays) / nrofdays * 100;
            if (percentage>=40 && percentage <= 60)
            {
                MessageBox.Show("yes my date 20.02.2018 is between 40% and 60%");
            }
