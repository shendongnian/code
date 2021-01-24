    void Main()
    {
    	var myData = new List<MyClass> {
    		new MyClass {Date=new DateTime(2018,6,10),Category="Category 1"},
    		new MyClass {Date=new DateTime(2018,6,11),Category="Category 1"},
    		new MyClass {Date=new DateTime(2018,6,12),Category="Category 2"},
    		new MyClass {Date=new DateTime(2018,6,13),Category="Category 1"},
    		new MyClass {Date=new DateTime(2018,6,15),Category="Category 3"},
    		new MyClass {Date=new DateTime(2018,7,20),Category="Category 1"},
    		new MyClass {Date=new DateTime(2018,7,21),Category="Category 1"},
    		new MyClass {Date=new DateTime(2018,8,4),Category="Category 4"},
    		new MyClass {Date=new DateTime(2018,8,5),Category="Category 2"},
    	};
    
    
    	var result = from c in myData.Select(d => d.Category).Distinct()
    				 let months = myData.Select(d => d.Date.Month).Distinct().OrderBy(d => d).ToArray()
    				 let m1 = months[0]
    				 let m2 = months[1]
    				 let m3 = months[2]
    				 select new {
    					 name = c,
    					 data = new int[] {
    					 	myData.Count(d => d.Category == c && d.Date.Month==m1),
    					 	myData.Count(d => d.Category == c && d.Date.Month==m2),
    					 	myData.Count(d => d.Category == c && d.Date.Month==m3),
    					 }
    				 };
    
    	var json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
    	Console.WriteLine(@"""series"": " + json);
    }
    
    public class MyClass
    {
    	public DateTime Date { get; set; }
    	public string Category { get; set; }
    }
