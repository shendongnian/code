       Dictionaries are special lists, whereas every value in the list has a key 
       which is also a variable. A good example of a dictionary is a phone book.
    
      CODE>>
    
       Dictionary<string, long> phonebook = new Dictionary<string, long>();
        phonebook.Add("Alex", 4154346543);
        phonebook["Jessica"] = 4159484588;
    
       Notice that when defining a dictionary, we need to provide a generic 
       definition with two types - the type of the key and the type of the value. In this case, the key is a string whereas the value is an integer.
    
    There are also two ways of adding a single value to the dictionary, either using the brackets operator or using the Add method.
    
    To check whether a dictionary has a certain key in it, we can use the ContainsKey method:
    Dictionary<string, long> phonebook = new Dictionary<string, long>();
    phonebook.Add("Alex", 415434543);
    phonebook["Jessica"] = 415984588;
    
    if (phonebook.ContainsKey("Alex"))
    {
        Console.WriteLine("Alex's number is " + phonebook["Alex"]);
    }
    
    To remove an item from a dictionary, we can use the Remove method. Removing an item from a dictionary by its key is fast and very efficient. When removing an item from a List using its value, the process is slow and inefficient, unlike the dictionary Remove function.
    
    Dictionary<string, long> phonebook = new Dictionary<string, long>();
    phonebook.Add("Alex", 415434543);
    phonebook["Jessica"] = 415984588;
    
    phonebook.Remove("Jessica");
    Console.WriteLine(phonebook.Count);
