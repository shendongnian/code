        DateTime? a = null;
        if (!a.HasValue)
        {
            a = DateTime.Now;
            if (a.HasValue)
            {
                Console.WriteLine(a.Value);
            }
        }
