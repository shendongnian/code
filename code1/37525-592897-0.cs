    public voidMyFunction()
    {
    
       Func<string> myFunction=(s)=>Console.WriteLine(s);
    
       foreach(string str in myStringList)
       {
          myFunction(str);
       }
    }
