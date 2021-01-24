    string desiredTime = "10/10/2017 09:18";
            DateTime d = DateTime.Parse(desiredTime);
            string existingTime = "10/10/2017 10:18";
            DateTime e = DateTime.Parse(existingTime);
            if ((e-d).Hours <= 1)
            {
                Console.WriteLine("true");
            }
