    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var response = new List<ResponseClass>();
                var listOfStudents = new List<Student>();
                // Insert some objects into listOfStudents object.
                listOfStudents.GroupBy(g => g.Class).ToList()
                    .ForEach(g => response.Add(g.OrderByDescending(s => s.CreatedOn).Select(a =>
                    new ResponseClass
                    {
                        SName = a.StudentName,
                        SAge = a.Age,
                        SClass = a.Class,
                        SCreatedOn = a.CreatedOn,
                        RandomProperty = Guid.NewGuid().ToString()
                    })
                    .First()));
                    Console.WriteLine("This compiles and should work just fine");
    	}
    	class Student
        {
            public string StudentName { get; set; }
            public int Age { get; set; }
            public string Class { get; set; }
            public DateTime CreatedOn { get; set; }
        }
    
        class ResponseClass
        {
            public string SName { get; set; }
            public int SAge { get; set; }
            public string SClass { get; set; }
            public DateTime SCreatedOn { get; set; }
            public string RandomProperty { get; set; }
        }
    }
