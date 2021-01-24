    RootObjectNew RootObjectNewObject = new RootObjectNew();
    RootObject obj = JsonConvert.DeserializeObject<RootObject>(Out);
    foreach (var stu in obj.Students)
    {   
        var st = new StudentNew{
          Id=Stu.Id,
          ...
        };
        RootObjectNewObject.StudentsNew.Add(st);
        
    }
