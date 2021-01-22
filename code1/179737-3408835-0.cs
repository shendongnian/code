    public class MyClass
    {
       public int AreaCount;
       public string foo;
       public bool bar;
    }
    //Create dictionary to hold, and a loop to make, objects:
    Dictionary<string, MyClass> myDict = new Dictionary<string, MyClass>();
    while(condition)
    { 
       string name = getName(); //To generate the string keys you want
       MyClass mC = new MyClass();
       myDict.Add(name, mC);
    }
    //pull out yours and modify AreaCount
    myDict["Area1"].Value.AreaCount = 50;
