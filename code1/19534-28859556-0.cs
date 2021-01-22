    using ADODB;
    using System;
    using System.Data;
    using System.IO;
    
    namespace ConsoleApplicationTests
    {
        class Program
        {
            static void Main(string[] args)
            {
                Recordset rs = new Recordset();
                DataTable dt = sampleDataTable();   //-i. -> SomeFunctionThatReturnsADataTable() 
    
                //-i. Convert DataTable to Recordset 
                rs = ConvertToRecordset(dt);
    
                //-i. Sample Output File
                String filename = @"C:\yourXMLfile.xml";
                FileStream fstream = new FileStream(filename, FileMode.Create);
    
                rs.Save(fstream, PersistFormatEnum.adPersistXML);
            }
        }
    }
