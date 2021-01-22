    public class IDnumber 
        { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string year { get; set; } 
            public string class1 { get; set; } 
            public string class2 { get; set; } 
            public string class3 { get; set; } 
            public string class4 { get; set; } 
     
     
           public static void ProcessNumber(IDnumber myNum) 
                { 
                    StringBuilder myData = new StringBuilder(); 
                    myData.AppendLine(IDnumber.Name);    
                    myData.AppendLine(": ");    
                    myData.AppendLine(IDnumber.ID);    
                    myData.AppendLine(IDnumber.year);    
                    myData.AppendLine(IDnumber.class1);// i get it for all of these    
                    myData.AppendLine(IDnumber.class2);    
                    myData.AppendLine(IDnumber.class3);    
                    myData.AppendLine(IDnumber.class4);   
                    MessageBox.Show(myData); 
                } 
