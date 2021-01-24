    public class StudentDataContainer 
    {
        public StudentData StudentData { get; set; }
    }
    
    var data = await req.Content.ReadAsAsync<StudentDataContainer>();
