    List<string> names = new List<string>();
    
    names.Add("jonh");
    names.Add("mary");
    
    string name = String.Empty;    
    name = names.NextOf(null); //name == jonh
   
    name = names.NextOf("jonh"); //name == mary
    name = names.NextOf("mary"); //name == jonh
