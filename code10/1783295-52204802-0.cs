    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace Sample
    {
        public class StudentDetails
        {
            public string StudentName { get; set; }
            public string RegistrationNo { get; set; }
            public string Grade { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var input = @"{ ""John"": { ""StudentName"": ""John anow"", ""RegistrationNo"": ""xxxxx"", ""Grade"":""B""},
    ""Methwe 0"": { ""StudentName"": ""Methew"", ""RegistrationNo"": ""xxxxx"", ""Grade"":""B""},
    ""Johnsan 09"": { ""StudentName"": ""Johnsan anow"", ""RegistrationNo"": ""xxxxx"", ""Grade"":""B""}
            }";
    
    
                var output = JsonConvert.DeserializeObject<Dictionary<string, StudentDetails>>(input);
    
                Console.ReadLine();
    
            }
        }
    }
