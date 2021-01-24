    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace ParsingJSON
    {
        class Program
        {
            static void Main(string[] args)
            {
                // code to deserialize from JSON string to a typed object
                string json = @"{
        'TransferResult': 'SUCCESS',
        'City': 'California',
        'State': 'CA',
        'Applications': [
            {'AppSerial' : 'APX3531'},
            {'AppSerial' : 'APX3263'},
            {'AppSerial' : 'APX3251','OfficialResult' : 'PENDING'},
            {'AppSerial' : 'APX3228'},
            {'AppSerial' : 'APX9521'},
            {'AppSerial' : 'APX3251','OfficialResult' : 'APPROVED'},
    
        ]}";
    
                Application app = JsonConvert.DeserializeObject<Application>(json);
    
                if(app.TransferResult == "SUCCESS")
                {
                    // if TransferResult == SUCCESS
                    // grab the City, State, AppSerial, and OfficialResult if any
                    Console.WriteLine(app.City);
                    Console.WriteLine(app.State);
                    Console.WriteLine(app.AppSerial); // make key value pairs of AppSerial and values and OfficialResults and results
                    Console.WriteLine(app.OfficialResult); // if any
                    Console.ReadLine();
                }
    
    
    
            } // Main
            public class Application
            {
                public string TransferResult { get; set; } //SUCCESS or FAIL
                public string City { get; set; } // California.
                public string State { get; set; } // CA
                public List<ApplicationDetail> Applications { get; set; }
            } //Application
            public class ApplicationDetail
            {
                public string AppSerial { get; set; }
                public string OfficialResult { get; set; }
            } // ApplicationDetail
    
        } // Program
    } //namespace
