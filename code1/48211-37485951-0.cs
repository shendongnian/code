    static void Main(string[] args){
    	var obj = GetMultipleValues();
    	Console.WriteLine(obj.Id);
    	Console.WriteLine(obj.Name);
    }
    
    private static dynamic GetMultipleValues() {
    	dynamic temp = new System.Dynamic.ExpandoObject();
    	temp.Id = 123;
    	temp.Name = "Lorem Ipsum";
    	return temp;
    }
