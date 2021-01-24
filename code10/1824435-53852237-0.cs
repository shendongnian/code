    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class StudyOptions {
            public decimal price { get; set; }
            public string currency { get; set; }
            public string currencyIdentifier { get; set; }
            public bool lowGDP { get; set; }
            public string method { get; set; }
        }
        
        public class Program
        {
            public static void Main(string[] args)
            {            
                List<StudyOptions> defaultOptions = new List<StudyOptions>();
                defaultOptions.Add(new StudyOptions{ price = 0, currency = "t", currencyIdentifier = ".", lowGDP = false, method = "method"});
                foreach(var studyOptions in defaultOptions){
                    if(studyOptions.method.Contains("method") )
                        Console.WriteLine(studyOptions);
                }
                
            }
            
        }
    }
