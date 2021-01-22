    using System;
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Text; 
    using System.IO;
    
    namespace measurementConverter { 
        class Program 
        { 
            static void Main(string[] args) 
            {  //read in the file 
                StreamReader convert = new StreamReader("../../convert.txt");
                
                //define variables
                string line = convert.ReadLine();
                double conversion;
                int numberIn;
                double conversionFactor;
    
                Console.WriteLine("Enter the conversion in the form (amount,from,to)");
                String inputMeasurement = Console.ReadLine();
                string[] inputMeasurementArray = inputMeasurement.Split(',');
    
                while (line != null)
                {
                    string[] fileMeasurementArray = line.Split(',');
                    if (fileMeasurementArray[0] == inputMeasurementArray[1])
                    {
                        if (fileMeasurementArray[1] == inputMeasurementArray[2])
                        {
                            Console.WriteLine("{0}", fileMeasurementArray[2]);
                        }
                    }
    
                    line = convert.ReadLine();
    
                    //convert to int
                    numberIn = Convert.ToInt32(inputMeasurementArray[0]);
                    conversionFactor = Convert.ToDouble(fileMeasurementArray[2]);
    
                    conversion = (numberIn * conversionFactor);
                }
    
    
    
                Console.ReadKey();
    
    
            }
        }
    }
