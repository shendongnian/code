    void Main()
    {
    	
    	myClass A = new myClass { Id=1, Category=1, Text="Hello World!"};
    	myClass B = new myClass { Id=2, Category=2, Text="Hello World!"};
    	myClass C = new myClass { Id=3, Category=2, Text="Good Bye!"};
    	myClass D = new myClass { Id=4, Category=7, Text="Hello World!"};
    	List<myClass> myList = new List<myClass>(); 
    	myList.AddRange(new []{ A, B, C, D });
    	
    	  var sublist = (from a in myList                
    	  from b in myList                
    	  where a.Text == b.Text                   
    	  && a.Id != b.Id                
    	  select a).Distinct();
    	  
    	  sublist.Dump();
    }
    public class myClass{  public int Id { get; set; }  public int Category { get; set; }  public string Text { get; set; }}
	
