            string date = "10/10/2017 09:18";
            DateTime d = DateTime.Parse(date);
            if(d.Hour == DateTime.Now.AddHours(-1).Hour)
            {
                Console.WriteLine("true");
            }
