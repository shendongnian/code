    using System;
    using RestSharp;
    using RestSharp.Authenticators;
    public class Program
    {
        //This gets meta tags for the SS project and issue type "Ticket"
        // https://HOST.atlassian.net/rest/api/2/issue/createmeta?projectKeys=SS&issuetypeNames=Ticket&expand=projects.issuetypes.fields
        public static string url = "https://HOST.atlassian.net/rest/api/2/issue";
        public static string username = "YOURUSERNAME";
        public static string password = "YOURAPIKEY";
        //host:port/context/rest/api-name/api-version/resource-name
        static void Main(string[] args)
        {
            var fieldPriority = "Low";
            var fieldSubject = "Payment Problem";
            var fieldTechResource = "BLAH";
            NewJiraIssue(fieldSubject,fieldPriority, fieldTechResource);
        }
        //*****************************************
        //        Create a new Jira Issue
        //*****************************************
        //INPUT:             OUT: New Ticket Number
        //*****************************************
        static void NewJiraIssue(string fieldSubject, string fieldPriority, string fieldTechResource)
        {
            try
            {
                var client = new RestClient("https://HOST.atlassian.net/rest/api/latest/issue");
    var request = new RestRequest(Method.POST);
    request.AddHeader("Postman-Token", "ad6dbffb-89fe-4b21-b59a-0dc60724510f");
    request.AddHeader("Cache-Control", "no-cache");
    request.AddHeader("Authorization", "Basic 
    KEY FROM ");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
    request.AddHeader("Content-Type", "application/json");                                                                                                                                                                                                                                                                                            
    //Created Date                                                                                                                                                                                                                                                        
    //Date CR Is approved internal                                   //Customer Approval 
    Sent Date                                        //Customer Approval Date:                                           
    //Planned UAT Completion Date:                                      //Actual Delivery 
    Date to UAT:                                                                                                                                                                                                                                                                                                                          
                request.AddParameter("undefined", "{\r\n    \"fields\": {\r\n       
    \"project\":\r\n       {\r\n          \"key\": \"SS\",\r\n           \"id\": 
    \"10040\"\r\n       },\r\n       \"summary\": \""+fieldSubject+"\",\r\n       \r\n       
    \"issuetype\": {\r\n          \"name\": \"Ticket\"\r\n       },\r\n       
    \"customfield_10042\" : \"2010-03-01T00:00:00.000+0400\",\r\n       
    \"customfield_10043\" : \"customfield_10043\",\r\n\r\n       \"customfield_10067\" :  
    \"customfield_10067\",\r\n       \"customfield_10068\" : 
    \"customfield_10068\",\r\n\r\n       \"customfield_10070\" : \"2001-03- 
    01T00:00:00.000+0400\",\r\n       \"customfield_10071\" : \"2002-03- 
    01T00:00:00.000+0400\",\r\n       \"customfield_10072\" : \"2003-03- 
    01T00:00:00.000+0400\",\r\n       \"customfield_10073\" : \"2004-03- 
    01T00:00:00.000+0400\",\r\n       \"customfield_10074\" : \"2005-03- 
    01T00:00:00.000+0400\",\r\n       \r\n       \"priority\": {\"name\": \"" + 
     fieldPriority + "\"},\r\n       \"customfield_10069\":  {\"name\" : \"" + 
    fieldTechResource + "\"}\r\n}\r\n}", ParameterType.RequestBody);
    IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
