    using System;					
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class Student {
    	public String name { get; set; }
    	public String id { get; set; }
    	public Int32 status { get; set; }
    	public override String ToString() {
    		return name + "(" + id + "): " + status.ToString();
    	}
    }
    
    public class StudentSchedule {
    	public IList<Student> morning { get; set; }
    	public IList<Student> afternoon { get; set; }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		String myJson = @"{
        'morning': 
        [
            {
                'name': 'Morning Student 1',
                'id': '123456',
                'status': '0'
            }
        ],
        'afternoon': 
        [
            {
                'name': 'Afternoon Student 1',
                'id': '123456',
                'status': '0'
            }
        ]
    }";
    		StudentSchedule studentSchedule = JsonConvert.DeserializeObject<StudentSchedule>(myJson);
    		Console.WriteLine("========== MORNING ===========");		
    		foreach(Student student in studentSchedule.morning) {
    			Console.WriteLine(student);
    		}
    		Console.WriteLine("========== AFTERNOON ===========");		
    		foreach(Student student in studentSchedule.afternoon) {
    			Console.WriteLine(student);
    		}
    	}
    }
