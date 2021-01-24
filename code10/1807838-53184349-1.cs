    class T
    {
    	public string QuestionName { get; set;}
    
    	public string Response { get; set;}
     }
    
    
    void Main()
    {
    	List<List<T>> myList = new List<List<T>>();
    
    	List<T> tList = new List<T>();
    	tList.Add(new T { QuestionName = "FirstName", Response = "BBB"});
    	tList.Add(new T{ QuestionName = "LastName", Response = "BBBLastName"});
    	myList.Add(tList.OrderBy(x => x.Response).ToList());
    
    	List<T> tList1 = new List<T>();
    	tList1.Add(new T{ QuestionName = "FirstName", Response = "AAA"});
    	tList1.Add(new T{ QuestionName = "LastName", Response = "AAACLastName"});
    	myList.Add(tList1.OrderBy(x => x.Response).ToList());
    
    	List<T> tList2 = new List<T>();
    	tList2.Add(new T{ QuestionName = "FirstName", Response = "CCC"});
    	tList2.Add(new T{ QuestionName = "LastName", Response = "CCCLastName"});
    	myList.Add(tList2.OrderBy(x => x.Response).ToList());
    	
    	myList =
    	myList.OrderBy(list => list.First().Response).ToList();
    }
