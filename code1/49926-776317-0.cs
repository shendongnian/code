    using System;
    using System.Web.Script.Serialization;
    class App 
    {
        static void Main(string[] args = null)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            String sJson = "{\"Name\": \"Your name\"}";
            DesJson json = jss.Deserialize<DesJson>(sJson);
            Console.WriteLine(json.Name);
        }
    }
    class DesJson {
        public string Name {get; set;}
    }
