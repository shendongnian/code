    using System;
    using NHapi.Model;
    using NHapi.Model.V231;
    using NHapi.Model.V231.Message;
    using NHapi.Base.Parser;
    using NHapi.Base.Model;
    using System.Diagnostics;
    
    namespace HL7parser
    {
        class Program
        {
            static void Main(string[] args)
            {
                String msg =
                "MSH|^~\\&|HIS|RIH|EKG|EKG|199904140038||ADT^A01||P|2.2\r";
                PipeParser parser = new PipeParser();
                try
                {
                    IMessage mssg = parser.Parse(msg);
                    XMLParser xMLParser = null;
    
                    xMLParser = new DefaultXMLParser(new DefaultModelClassFactory());
    
    
                    String str = xMLParser.Encode(mssg);
                    Debug.Print(str);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.GetType().Name);
                    Console.WriteLine(e.StackTrace);
                }
                Console.WriteLine("\n Press Enter to continue...");
                Console.Read();
            }
        }
    }
    
     
