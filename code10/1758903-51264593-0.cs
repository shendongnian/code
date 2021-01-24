    public class sampleClass{
        
    	private IList myList;
     
    	public IList MyList
        {
           get { return myList ; }
           set { myList = value; }
        }
    }
   
    // Usage
    sampleClass objClass = new sampleClass();
    objClass.MyList = new List<string> { "A", "B", "C" };
	Console.WriteLine(objClass.MyList.Count); // Will print 3
    Console.WriteLine(objClass.MyList[0]); // will print A
	objClass.MyList.Clear();
	Console.WriteLine(objClass.MyList.Count); // Will print 0
    Console.WriteLine(objClass.MyList[0]); // will throw Index was out of range Exception
