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
        public static class Tuple
        {
            //Allows Tuple.New(1, "2") instead of new Tuple<int, string>(1, "2")
            public static Tuple<T1, T2> New<T1, T2>(T1 v1, T2 v2)
            {
                return new Tuple<T1, T2>(v1, v2);
            }
        }
        public class Tuple<T1, T2>
        {
            public Tuple(T1 v1, T2 v2)
            {
                V1 = v1;
                V2 = v2;
            }
            public T1 V1 { get; set; }
            public T2 V2 { get; set; }
        }
        public class launchpad
        {
            public void Run()
            {
                // see http://tinyurl.com/yfkhwkq
                string address = "https://edge.launchpad.net/+request-token";
                var stuff = new List<Tuple<String,String>>();
                stuff.Add(Tuple.New("oauth_consumer_key", "stackoverflow1"));
                stuff.Add(Tuple.New("oauth_signature_method", "PLAINTEXT"));
                stuff.Add(Tuple.New("oauth_signature", "%26"));
                string data =
                    String.Join("&",stuff.ConvertAll(t => String.Format("{0}={1}", t.V1, t.V2)).ToArray());
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
