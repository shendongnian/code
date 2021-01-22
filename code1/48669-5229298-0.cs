    AA D1=new AA(); //Derived type
    BB D2=new BB(); //Derived type 
    CC D3=new CC(); //Derived type 
    X D4=new X(); //Base Class 
    XList<X> AllData=new XList<X>(); 
    AllData.Add(D1); 
    AllData.Add(D2); 
    AllData.Add(D3); 
    AllData.Add(D4); 
    // ----------------------------------- 
    AllData.Save(@"C:\Temp\Demo.xml"); 
    // ----------------------------------- 
    // Retrieve data from XML file 
    // ----------------------------------- 
    XList<X> AllData=new XList<X>(); 
    AllData.Open(@"C:\Temp\Demo.xml"); 
    // -----------------------------------
