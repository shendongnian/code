    #r "SendGrid"
    #r "Newtonsoft.Json"
    using System;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs.Host;
    using Newtonsoft.Json;
    public static Mail Run(string telemetryEvent, TraceWriter log)
    {
        var telemetry = JsonConvert.DeserializeObject<Telemetry>(telemetryEvent);
    Mail message = new Mail()
    {
        Subject = "Write your own subject"
    };
    var personalization = new Personalization();
    personalization.AddBcc(new Email("sample1@test.com"));  
    personalization.AddTo(new Email("sample2@test.com")); 
    //add more Bcc,cc and to here as needed
    Content content = new Content
    {
        Type = "text/plain",
        Value = $"The temperature value is{temperature.Temperature}."
    };
    message.AddContent(content); 
    message.AddPersonalization(personalization); 
   
        return message;
    }
    
    
    public class Telemetry 
    {
        public float Temperature { get; set; }
    }
