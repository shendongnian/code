    list
    .GroupBy(x=>x.Date)
    .Select(x=> new
    {
     Name=x.Select(z=>z.Date),
     Date=x.Key,
     Sum=x.Sum(z=>z.Status == "OK" ? 10 : 5)
    }
    Assuming your class  is Id, Name, Date, Status
