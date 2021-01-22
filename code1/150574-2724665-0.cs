    using System;
    using System.IO;
    using System.Data;
    using System.Text;
    using System.Drawing;
    using System.Data.OleDb;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Drawing.Printing;
    using System.Collections.Generic;
    
    namespace Eagle_Eye_Class_Finder
    {
    
        public class GetSchedule
        {
            public class IDnumber
            {
                public string Name { get; set; }
                public string ID { get; set; }
                public string year { get; set; }
                public string class1 { get; set; }
                public string class2 { get; set; }
                public string class3 { get; set; }
                public string class4 { get; set; }
    
                IDnumber[] IDnumbers = new IDnumber[3];   
    
                static void ProcessNumber(IDnumber myNum)
                    {
                        StringBuilder myData = new StringBuilder();
                        myData.AppendLine(IDnumber.Name);   
                        myData.AppendLine(": ");   
                        myData.AppendLine(IDnumber.ID);   
                        myData.AppendLine(IDnumber.year);   
                        myData.AppendLine(IDnumber.class1);   
                        myData.AppendLine(IDnumber.class2);   
                        myData.AppendLine(IDnumber.class3);   
                        myData.AppendLine(IDnumber.class4);  
                        MessageBox.Show(myData);
                    }
    
                public string GetDataFromNumber(string ID)
                {
    
                   foreach (IDnumber idCandidateMatch in IDnumbers)  
    
                { 
    
                if (IDCandidateMatch.ID == ID)
                    {
                         StringBuilder myData = new StringBuilder();
                         myData.AppendLine(IDnumber.Name);   
                         myData.AppendLine(": ");   
                         myData.AppendLine(IDnumber.ID);   
                         myData.AppendLine(IDnumber.year);   
                         myData.AppendLine(IDnumber.class1);   
                         myData.AppendLine(IDnumber.class2);   
                         myData.AppendLine(IDnumber.class3);   
                         myData.AppendLine(IDnumber.class4);  
                         return myData;
            }
        }
        return "";
    }
            }
    
            public GetSchedule() //here i get an error saying method must have a return type???
            {
                IDnumbers[0] = new IDnumber() { Name = "Joshua Banks", ID = "900456317", year = "Senior", class1 = "TEET 4090", class2 = "TEET 3020", class3 = "TEET 3090", class4 = "TEET 4290" };
                IDnumbers[1] = new IDnumber() { Name = "Sean Ward", ID = "900456318", year = "Junior", class1 = "ENGNR 4090", class2 = "ENGNR 3020", class3 = "ENGNR 3090", class4 = "ENGNR 4290" };
                IDnumbers[2] = new IDnumber() { Name = "Terrell Johnson", ID = "900456319", year = "Sophomore", class1 = "BUS 4090", class2 = "BUS 3020", class3 = "BUS 3090", class4 = "BUS 4290" };
    
            }
    
        }
    }
