    string newManagerName = "Some Random Name";
    string manager = "CN=Kylie Seany,OU=Test,OU=Users";
    
    int index = manager.IndexOf(",OU=");
            
    string newManager = "CN=" + newManagerName + manager.Substring(index);
    Console.WriteLine(newManager);
