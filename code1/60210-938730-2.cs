    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    public class ErrorType
    {
        public String Name { get; set; }
        public bool Ignore { get; set; }
    
        public List<ErrorType> ChildErrors { get; protected set; }
        public ErrorType()
        {
            ChildErrors = new List<ErrorType>();
        }
    }
    
    public class ErrorList
    {
        public List<ErrorType> ChildErrors { get; protected set; }
        public ErrorList()
        {
            ChildErrors = new List<ErrorType>();
        }
    }
    
    public class Test
    {
        public static void Main()
        {
            var childError2 = new ErrorType { 
                Name = "ChildErrorName2", Ignore=false };
            var childError1 = new ErrorType {
                Name = "ChildErrorName1", Ignore=true,
                ChildErrors = { childError2 }
            };
            var mainError = new ErrorType {
                Name = "ErrorName1", Ignore=true,
                ChildErrors = { childError1 }
            };
            var errorList = new ErrorList { ChildErrors = { mainError } };
            
            // Need to declare in advance to call within the lambda.
            Func<ErrorType, XElement> recursiveGenerator = null;
            recursiveGenerator = error => new XElement
                (error.Name,
                 new XAttribute("Ignore", error.Ignore),
                 error.ChildErrors.Select(recursiveGenerator));
    
            var element = new XElement
                 ("ErrorList", 
                  errorList.ChildErrors.Select(recursiveGenerator(x));
                  
            Console.WriteLine(element);
        }        
    }
