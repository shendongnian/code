    Customer {
       public Dictionary<string, List<string>> Characteristics;
       .
       .
       .
    }
    
    ...
    
    Characteristics.Add("Interest", new List<string>());
    Characteristics["Interest"].Add("Post questions on StackOverflow");
    Characteristics["Interest"].Add("Answer questions on StackOverflow");
    ..
    
    List<Characteristic> interestCharacteristics = Characteristics["Interest"];
    
