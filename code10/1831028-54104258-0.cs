    for (int i = 0; i < countOfWorkers; i++)
    {
        var driver = new Driver
        {
            // i belive that constructor launch in here
            Id = i + 1,
            FirstName = "name" + i,
            LastName = "lastname" + i,
            UsdPerHour = Math.Round((random.NextDouble() * 20), 2),
            HoursPerDay = random.Next(1, 23),
            DaysOfWork = random.Next(1, 31)
        };
        driver.BaseSalary = driver.CountBaseSalary();
        modelBuilder.Entity<Driver>().HasData(driver);
    }
