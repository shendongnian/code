    delegate void AsFunction(string str, string str);// as many arguments as you want
    public DoOperations(AsFunction asFunction)
    {
            asFunction("hello1", "hello2");
        
    }
   
    
