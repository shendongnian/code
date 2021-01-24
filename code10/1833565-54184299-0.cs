    using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
    using System;
    using System.IO;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string b = "eJwLSEzOVsitVEjKr1AozyzJUEjLLEtVSMmvSs1TyMksLM0vUsgqTS/WAwAm/w6Y";
                string s = Decode(b);
                Console.WriteLine(b);
                Console.WriteLine(s);
                Console.ReadKey(true);
            }
            public static string Decode(string base64)
            {
                byte[] bytes = Convert.FromBase64String(base64);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    using (InflaterInputStream ds = new InflaterInputStream(ms))
                    {
                        using (StreamReader sr = new StreamReader(ds))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
