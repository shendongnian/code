    void Main()
    {
    	var myObjects = new List<MyClass>();
    	myObjects.Add(new MyClass());
    	myObjects.Add(new MyClass());
    	myObjects.Add(new MyClass());
    
    	var numbers = new int[] { 1, 2, 3 };
    	
    	for(var i = 0; i < myObjects.Count; i++)
    	{
    		myObjects.ElementAt(i).Number = numbers[i];
    		Console.WriteLine($"myObjects.ElementAt(i).Number = {myObjects.ElementAt(i).Number}");
    	}
    
        //	myObjects.ElementAt(i).Number = 1
        //	myObjects.ElementAt(i).Number = 2
        //	myObjects.ElementAt(i).Number = 3
    }
    
    class MyClass
    {
    	public int Number;
    	public int AnotherNumber;
    	public void WorkWithNumber() { /* Do some work. */ }
    }
