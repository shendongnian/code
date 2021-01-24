        1. To store appname
        
        `public class appName{
         public string description{get;set;}
         public string message {get;set;}
        }`
        
        2. store appdescription
        
            public class appDesc{
            public string description{get;set;}
            public string message {get;set;}
            }
        
        3. A class to have both above classes as properties
        
            public class appResult{
            public appDesc appDesc {get;set;}
            public appName appName {get;set;}
            
            public appResult(){
            appDesc = new appDesc();
            appName = new appName();
            }
            }
            }
        
        4. desirialize the json
        
            var result = JsonConvert.DeserializeObject<appResult>(msg);
    
        5. Once you have the result object you can get your `appName` 
            var appName =result.appName;
