    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.Reflection;
    // to allow fast ngen
    [assembly: AssemblyTitle("launchpad.cs")]
    [assembly: AssemblyDescription("insert purpose here")]
    [assembly: AssemblyConfiguration("")]
    [assembly: AssemblyCompany("Dino Chiesa")]
    [assembly: AssemblyProduct("Tools")]
    [assembly: AssemblyCopyright("Copyright © Dino Chiesa 2010")]
    [assembly: AssemblyTrademark("")]
    [assembly: AssemblyCulture("")]
    [assembly: AssemblyVersion("1.1.1.1")]
    namespace Cheeso.ToolsAndTests
    {
        public class launchpad
        {
            public void Run()
            {
                // see http://tinyurl.com/yfkhwkq
                string address = "https://edge.launchpad.net/+request-token";
                string oauth_consumer_key = "stackoverflow1";
                string oauth_signature_method = "PLAINTEXT";
                string oauth_signature = "%26";
                string[] listOfData ={
                    "oauth_consumer_key="+oauth_consumer_key,
                    "oauth_signature_method="+oauth_signature_method,
                    "oauth_signature="+oauth_signature
                };
                string data = String.Join("&",listOfData);
                string reply = null;
                using (WebClient client = new WebClient ())
                {
                    client.Headers.Add("Content-Type","application/x-www-form-urlencoded");
                    reply = client.UploadString (address, data);
                }
                System.Console.WriteLine("response: {0}", reply);
            }
            public static void Usage()
            {
                Console.WriteLine("\nlaunchpad: request token from launchpad.net\n");
                Console.WriteLine("Usage:\n  launchpad");
            }
            public static void Main(string[] args)
            {
                try
                {
                    new launchpad()
                        .Run();
                }
                catch (System.Exception exc1)
                {
                    Console.WriteLine("Exception: {0}", exc1.ToString());
                    Usage();
                }
            }
        }
    }
