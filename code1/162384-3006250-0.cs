    protected void Page_Load(object sender, EventArgs e)
    {
        var courseId = int.Parse(Request["id"]);
        var course = Course.Queryable.Single(x => x.Id == courseId);
        Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}.csv\";", course.Code));
        var csvContext = new LINQtoCSV.CsvContext();
        var writer = new System.IO.StreamWriter(Response.OutputStream);
        csvContext.Write(course.Registrations.Select(x => new
        {
            x.StudentId,
            x.Name,
            x.EmailAddress,
            x.MoodleUsername,
            x.Age,
            x.Is65OrOlder,
            x.CertificationAndRank,
            x.Citizenship,
            x.DateOfBirth,
            x.DepartmentName,
            x.StationNumber,        
            x.EmploymentStatus,
            x.HighestEducationLevel
        }), writer);        
        
        writer.Dispose();
    }
