    // CSV Class
    
    public class CsvRegistration
    {
        [CsvColumn(FieldIndex = 0)]
        public string Name { get; set; }
    
        [CsvColumn(FieldIndex = 1, Name = "Student Id")]
        public int StudentId { get; set; }
    
        [CsvColumn(FieldIndex = 2, Name = "Email Address")]
        public string EmailAddress { get; set; }
    
        [CsvColumn(FieldIndex = 3, Name = "Moodle Username")]
        public string MoodleUsername { get; set; }
    
        [CsvColumn(FieldIndex = 4, Name = "Dept. Name")]
        public string DepartmentName { get; set; }
    
        [CsvColumn(FieldIndex = 5, Name = "Station #")]
        public string StationNumber { get; set; }
    
        [CsvColumn(FieldIndex = 6, Name = "Highest Education Level")]
        public string HighestEducationLevel { get; set; }
    
        [CsvColumn(FieldIndex = 7, Name = "Certification/Rank")]
        public string CertificationAndRank { get; set; }
    
        [CsvColumn(FieldIndex = 8, Name = "Employment Status")]
        public string EmploymentStatus { get; set; }
    
        [CsvColumn(FieldIndex = 9, Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }
    
        [CsvColumn(FieldIndex = 10, Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    
        [CsvColumn(FieldIndex = 11)]
        public int Age { get; set; }
    
        [CsvColumn(FieldIndex = 12)]
        public string Citizenship { get; set; }
    
        [CsvColumn(FieldIndex = 13)]
        public string Race { get; set; }
    
        [CsvColumn(FieldIndex = 14)]
        public string Ethnicity { get; set; }
    
        [CsvColumn(FieldIndex = 15, Name = "Home Address")]
        public string HomeAddressLine1 { get; set; }
    
        [CsvColumn(FieldIndex = 16, Name = "City")]
        public string HomeAddressCity { get; set; }
    
        [CsvColumn(FieldIndex = 17, Name = "State")]
        public string HomeAddressState { get; set; }
    
        [CsvColumn(FieldIndex = 18, Name = "Zip")]
        public string HomeAddressZip { get; set; }
    
        [CsvColumn(FieldIndex = 19, Name = "County")]
        public string HomeAddressCounty { get; set; }
    
        [CsvColumn(FieldIndex = 20, Name = "Home Phone")]
        public string HomePhone { get; set; }
    
        [CsvColumn(FieldIndex = 21, Name = "Work Phone")]
        public string WorkPhone { get; set; }
    }
    // ASPX page to serve csv file
    protected void Page_Load(object sender, EventArgs e)
    {
        var courseId = int.Parse(Request["id"]);
        var course = Course.Queryable.Single(x => x.Id == courseId);
        Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}.csv\";", course.Code));
        
        using (var writer = new System.IO.StreamWriter(Response.OutputStream))
        {
            var registrations = Mapper.Map<IEnumerable<Registration>, IEnumerable<CsvRegistration>>(course.Registrations);
            var cc = new LINQtoCSV.CsvContext();
            cc.Write(registrations, writer);
        }
    }
