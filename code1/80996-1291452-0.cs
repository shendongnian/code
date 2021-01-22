            DateTime start = new DateTime(1900, 1, 1, 9, 0, 0);
            DateTime end = new DateTime(1900, 1, 1, 17, 0, 0);
            DateTime current = start;
            while (current <= end)
            {
                Console.WriteLine(current.ToString("HH:mm"));
                current = current.AddMinutes(15);
            }
