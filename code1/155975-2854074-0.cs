    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.Xml;
    
    namespace XMLSerializationHelp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string strXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <data>
      <status>1</status>
      <message>OK</message>
      <results>
        <result>
          <account>12345</account>
          <to>012345678</to>
          <from>054321</from>
          <message>Testing</message>
          <flash></flash>
          <replace></replace>
          <report></report>
          <concat></concat>
          <id>f8d3eea1cbf6771a4bb02af3fb15253e</id>
        </result>
      </results>
    </data>";
    
                XmlSerializer serializer = new XmlSerializer(typeof(SMSSendingResponse));
                SMSSendingResponse obj = (SMSSendingResponse)serializer.Deserialize(new XmlTextReader(strXML, XmlNodeType.Document, null));
    
                Console.WriteLine("Status:         {0}", obj.Status);
                Console.WriteLine("Message:        {0}", obj.Message);
                Console.WriteLine("Account Number: {0}", obj.AccountNumber);
                Console.WriteLine("ResponseID:     {0}", obj.ResponseID);
                Console.WriteLine("To:             {0}", obj.To);
                Console.WriteLine("From:           {0}", obj.From);
                Console.WriteLine("ResultMessage:  {0}", obj.ResultMessage);
    
                Console.ReadLine();
            }
        }
    
        [Serializable]
        [XmlRoot("data")]
        public class SMSSendingResponse
        {
            public SMSSendingResponse() {}
    
            //should come from the "status" xml element
            [XmlElement("status")]
            public string Status { get; set; }
    
            //should come from the "message" xml element (in our example - "OK")
            [XmlElement("message")]
            public string Message { get; set; }
    
            //should come from the results/result/account element. in our example "12345"
            [XmlIgnore()]
            public string AccountNumber
            {
                get
                {
                    Result r = FirstResult;
                    return (r != null) ? r.AccountNumber : null;
                }
            }
    
            //should come from the "id" xml element (in our example - "f8d3eea1cbf6771a4bb02af3fb15253e")
            [XmlIgnore()]
            public string ResponseID
            {
                get
                {
                    Result r = FirstResult;
                    return (r != null) ? r.ResponseID : null; 
                }
            }
    
            [XmlIgnore()]
            public string To
            {
                get
                {
                    Result r = FirstResult;
                    return (r != null) ? r.To : null;
                }
            }
    
            [XmlIgnore()]
            public string From
            {
                get
                {
                    Result r = FirstResult;
                    return (r != null) ? r.From : null;
                }
            }
    
            [XmlIgnore()]
            public string ResultMessage
            {
                get
                {
                    Result r = FirstResult;
                    return (r != null) ? r.Message : null;
                }
            }
    
            [XmlArray("results"), XmlArrayItem("result", typeof(Result))]
            public List<Result> Results
            {
                get { return (_Results); }
                set { _Results = value; }
            } private List<Result> _Results = new List<Result>();
    
            [XmlIgnore()]
            public Result FirstResult
            {
                get
                {
                    return (_Results != null && _Results.Count > 0) ? _Results[0] : null;
                }
            }
    
        }
    
        [XmlType(TypeName = "result"), Serializable]
        public class Result
        {
            public Result() {}
    
            [XmlElement("account")]
            public string AccountNumber { get; set; }
    
            [XmlElement("to")]
            public string To { get; set; }
    
            [XmlElement("from")]
            public string From { get; set; }
    
            [XmlElement("message")]
            public string Message { get; set; }
    
            [XmlElement("id")]
            public string ResponseID { get; set; }
        }
    }
