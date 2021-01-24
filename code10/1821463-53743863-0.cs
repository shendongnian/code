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
