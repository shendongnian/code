            string a = "0";
            string b = "-15";
            DateTime d = DateTime.Now;
            if (d.AddDays(int.Parse(a)) == d)
            {
                Console.WriteLine("{0} does equal {1}!", d.AddDays(int.Parse(a)), d);
            }
