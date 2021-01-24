    class Program
    {
    	static void Main(string[] args)
    	{
    		var university = new University()
    		{
    			Student = 1,
    			Subjects = new List<Subject>()
    			{
    				new Subject() { Id = 1, Text = "Math" },
    
    				new Subject() { Id = 2, Text = "English" },
    			},
    
    		};
    	}
    }
    
    public class University
    {
    	public int Student { get; set; }
    
    	public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
    
    public class Subject
    {
    	public int Id { get; set; }
    
    	public string Text { get; set; }
    };
