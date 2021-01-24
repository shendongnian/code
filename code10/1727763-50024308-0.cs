      class Program
      {
        static void Main(string[] args)
        {
          var o = new
          {
            Id = 1,
            Name = "Patrick",
            Courses = new[] { new { Id = 1, Name = "C#" } }
          };
    
          Student student = null;
          Scholar scholar = null;
    
          if (o.CanBeConverted<Student>())
            student = o.ConvertToType<Student>();
          else if (o.CanBeConverted<Scholar>())
            scholar = o.ConvertToType<Scholar>();
    
          System.Console.WriteLine(student?.ToString());
          System.Console.WriteLine(scholar?.ToString());
    
          System.Console.ReadKey();
        }
      }
    
      public static class ObjectExtensions
      {
        public static bool CanBeConverted<T>(this object value) where T : class
        {
          var jsonData = JsonConvert.SerializeObject(value);
          var generator = new JSchemaGenerator();
          var parsedSchema = generator.Generate(typeof(T));
          var jObject = JObject.Parse(jsonData);
    
          return jObject.IsValid(parsedSchema);
        }
    
        public static T ConvertToType<T>(this object value) where T : class
        {
          var jsonData = JsonConvert.SerializeObject(value);
          return JsonConvert.DeserializeObject<T>(jsonData);
        }
      }
    
      public class Student
      {
        public int Id { get; set; }
        public string Name { get; set; }
        public Courses[] Courses { get; set; }
    
        public override string ToString()
        {
          return $"{Id} - {Name} - Courses: {(Courses != null ? String.Join(",", Courses.Select(a => a.ToString())) : String.Empty)}";
        }
      }
    
      public class Courses
      {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public override string ToString()
        {
          return $"{Id} - {Name}";
        }
      }
    
      public class Scholar
      {
        public int UniqueId { get; set; }
        public string FullName { get; set; }
    
        public override string ToString()
        {
          return $"{UniqueId} - {FullName}";
        }
      }
