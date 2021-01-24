    public class StudentDataContainer 
    {
        public StudentData StudentData { get; set; }
    }
    
    StudentDataContainer data = await req.Content.ReadAsAsync<StudentDataContainer>();
