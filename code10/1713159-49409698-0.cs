    using System.Collections.Generic;
    namespace Json
    {
        using System.IO;
        using System.Xml.Serialization;
        using Newtonsoft.Json.Linq;
        class Program
        {
            static void Main(string[] args)
            {
                var converter = new Converter();
                converter.Convert();
            }
        }
        class Converter
        {
            public void Convert()
            {
                //  your JSON string goes here
                var jsonString = @"{""status"":""Error"",""errorMessages"":{ ""1001"":""Schema validation Error"", ""1953"":""Another error""}}";
                // deconstruct the JSON
                var jObject = JObject.Parse(jsonString);
                var root = new Root { Status = jObject["status"].ToString(), ErrorMessages = new List<ErrorMessage>() };
                foreach (var errorMessageJsonObject in jObject["errorMessages"])
                {
                    var jProperty = (JProperty)errorMessageJsonObject;
                    var errorCode = System.Convert.ToInt16(jProperty.Name);
                    var errorDescription = jProperty.Value.ToString();
                    var errorMessage = new ErrorMessage() { ErrorCode = errorCode, ErrorDescription = errorDescription};
                    
                    root.ErrorMessages.Add(errorMessage);
                }
                // serialize as XML
                var xmlSerializer = new XmlSerializer(typeof(Root));
                string xml;
                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, root);
                    xml = textWriter.ToString();
                }
            }
        }
        public class Root
        {
            public string Status;
            public List<ErrorMessage> ErrorMessages;
        }
        public class ErrorMessage
        {
            public int ErrorCode;
            public string ErrorDescription;
        }
    }
