    public class Student
    {
    	public string Name { set; get; }
    	public int ID { set; get; }
    }
    
    class Program
    {
      static void Main(string[] args)
        {
    		Student[] students =
    		{
    		new Student { Name="zoyeb" , ID=1},
    		new Student { Name="Siddiq" , ID=2},
    		new Student { Name="sam" , ID=3},
    		new Student { Name="james" , ID=4},
    		new Student { Name="sonia" , ID=5}
    		};
    		
    		var studentCollection = from s in students select new { s.ID , s.Name};
    	
    		foreach (var student in studentCollection)
    		{
    			Console.WriteLine(student.Name);
    			Console.WriteLine(student.ID);
    		}
    	}
    }
