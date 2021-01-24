    ...
    JsonResponse = objReader.ReadLine();
    Patients patients = JsonConvert.DeserializeObject<Patients>(JsonResponse);
    
    var result = (from p in patients.patients
                  group p by new { p.ID, p.date } into grp
                  select new
                  {
                      Key = grp.Key,
                      Items = grp.ToList()
                  }).ToList();
    foreach (var item in result)
    {
        Console.WriteLine(item.Key.ID);
        Console.WriteLine(item.Key.date);
        Console.WriteLine();
        item.Items.ForEach(x => Console.WriteLine($"ID: {x.ID}, date: {x.date}, component: {x.component}, result: {x.result}"));
        Console.WriteLine();
    }
    Console.ReadLine();
