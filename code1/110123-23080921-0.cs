            DateTime[] dd = new DateTime[] { new DateTime(2014, 01, 10, 10, 15, 01),new DateTime(2014, 01, 10, 10, 10, 10) };
            int x = Convert.ToInt32((dd[0] - dd[1]).TotalMinutes);
            String unit = "days";
            if (x / 60 == 0)
            {
                unit = "minutes";
            }
            else if (x / 60 / 24 == 0)
            {
                unit = "hours";
                x = x / 60;
            }
            else
            {
                x = x / (60 * 24);
            }
            Console.WriteLine(x + " " + unit);
