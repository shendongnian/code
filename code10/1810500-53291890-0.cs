    using System;
    using System.IO;
    using Microsoft.VisualBasic.FileIO;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    class MyLearningOnlyCsvParser {
      
      public List<string[]> parseCSV(string path)
      {
        List<string[]> parsedData = new List<string[]>();
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
                parsedData.Add(fields);
    
                //Did more stuff here with each field.
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
    
