    RootObjectNew RootObjectNewObject = new RootObjectNew();
    RootObjectNewObject.StudentsNew = new List<StudentNew>();
    RootObject obj = JsonConvert.DeserializeObject<RootObject>(Out);
    foreach (var stu in obj.Students)
    {   
        var st = new StudentNew{
          StudentId=Stu.Id,
          ...
        };
        RootObjectNewObject.StudentsNew.Add(st);
        
    }
