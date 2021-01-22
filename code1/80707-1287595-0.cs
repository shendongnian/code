        public class test
        {
         public string title;
         public string name;
         public string surname;
        } 
        
        void  main()
        {
        List<test> t =  new List<test>();
        
        test t1 = new test();
        t1.title = "Mr.";
        t1.name = "John";
        t1.surname = "Doe";
        .
        .
        .
        test tn = new test();
        t.Add(t1);
        t.Add(t2);
        .
        .
        .
        .
        t.Add(tn);
        
        
        //Serialize to xml.
        try
        {
                        using (FileStream fs = new FileStream(szFileName, FileMode.Create))
                       {
                          XmlSerializer xs = new XmlSerializer(typeof(List<test>));
                          xs.Serialize(fs, t);
                       }
        
        }
        catch(Exception Ex)
        {
         Messagebox.Show(Ex.ToString());
        }
        
        
        //And deserialize the data from xml to objects
    try
    {
                          using (System.IO.FileStream fs = new FileStream(szDataFile,FileMode.Open))
                          {
                             System.Xml.Serialization.XmlSerializer xs = new XmlSerializer(typeof(List<test>));
                             List<test> t1 = new List<test>();
                            t1 =  xs.Deserialize(fs) as List<test>;
                          }
     }
     catch(Exception Ex)
     {
         Messagebox.Show(Ex.ToString());
     }
    
    }
