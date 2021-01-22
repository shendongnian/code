    using System;
    using System.IO;
    using Microsoft.Crm.Callout;
    
    namespace IncrementCompetitorNumber 
    {
        public class Increment : CrmCalloutBase
        {
            public override void PostCreate(CalloutUserContext userContext, CalloutEntityContext entityContext, string postImageEntityXml)
            {
                IncrementNumber();
            }
    
            private string IncrementNumber()
            {
                string ProjectAutoNumber = "D:\\CRM_Misc\\incrementers\\new_competitornumber.txt";
                string AutoNumber = "0"; 
                string ReturnThis = "0";
                int i = 0;
    
                lock(this)
    
                {
    
                TextReader tr = new StreamReader(ProjectAutoNumber);
    
                AutoNumber = tr.ReadLine();
    
                tr.Close();
    
                ReturnThis = AutoNumber;
    
                i = Convert.ToInt32(AutoNumber);
    
                i++;
    
                AutoNumber = i.ToString();
    
                TextWriter tw = new StreamWriter(ProjectAutoNumber);
    
                tw.WriteLine(AutoNumber);
    
                tw.Close();
    
                }
    
                return ReturnThis;
            }
        }
    }
