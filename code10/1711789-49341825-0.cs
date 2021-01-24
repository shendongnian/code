    public class CourseReport
    {
         public string Course { get; set; }
         public ICollection<int> Grades { get; set; }
    }
    // Reads the JSON file into a single string
    string json = File.ReadAllText(jfile);
    Console.WriteLine(json);
    // Parsing the information to a format json.net can work with
    var courseReport = JsonConvert.DeserializeObject<CourseReport>(json);
    foreach (var grade in courseReport.Grades)
    {
         Console.WriteLine(grade);
    }
