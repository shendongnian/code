    Random random = new Random();
        List<int> acum = new List<int>();
        while (acum.Count < 99)
        {
            int Number = random.Next(1, 100);
            if (!acum.Contains(Number))
            {
                acum.Add(Number);
            }
        }
