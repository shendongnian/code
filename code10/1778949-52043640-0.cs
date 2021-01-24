    var ser = JsonConvert.DeserializeObject<List<RootObject>>(jsonText);
    foreach (var s in ser)
    {
        string Studentid = s.Studentid;
        string  Grade = s.Grade;
         
        foreach(var course in ser.Courses)
        {  
            string smalldesc = course .smalldesc;
            string details = course .Details.collegeCode;
        }
    }
