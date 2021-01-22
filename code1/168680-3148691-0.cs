    using System;
    using System.IO;
    using Microsoft.VisualBasic.FileIO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                TextReader reader = new StringReader("('ABCDEFG', 123542, 'XYZ 99,9')");
                TextFieldParser fieldParser = new TextFieldParser(reader);
    
                fieldParser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                fieldParser.SetDelimiters(",");
    
                String[] currentRow; 
    
                while (!fieldParser.EndOfData)
                {
                    try
                    {
                         currentRow = fieldParser.ReadFields();
    
                         foreach(String currentField in currentRow)
                         {
                            Console.WriteLine(currentField);                        
                         }
                    }
                    catch (MalformedLineException e)
                    {
                        Console.WriteLine("Line {0} is not valid and will be skipped.", e);
                   }
                    
                } 
    
            }
        }
    }
