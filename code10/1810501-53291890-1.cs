    using System;
    using System.IO;
    using Microsoft.VisualBasic.FileIO;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    class MyLearningOnlyCsvParser {
      
      public List<Customer_Data> parseCSV(string path)
      {
        List<Customer_Data> parsedData = new List<Customer_Data>();
        string[] fields;
    
        TextFieldParser parser = null;
        string line = parser.ReadLine();
    
        try
        {
            /*TextFieldParser*/ parser = new TextFieldParser(@"c:\temp\test.csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
    
            while (!parser.EndOfData)
            {
                fields = parser.ReadFields();
    
                // assume the CSV is always with  11 columns
                if(fields.length == 11) {
                    Customer_Data newData = new Customer_Data();
                    newData.name = fields[0];
                    newData.company = fields[1];
                    // assign to the rest of the customer data properties with each fields
                    parsedData.Add(newData);
                }
                else {
                    // error handling of not well formed CSV
                }
                
            }
    
            parser.Close();
    
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    
       return parsedData;
      }
    }
    
