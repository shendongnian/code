    using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
    using System;
    using System.IO;
    using System.Text;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "Pack my box with five dozen liquor jugs.";
                string encoded = Encode(input);
                string decoded = Decode(encoded);
                Console.WriteLine($"Input: {input}");
                Console.WriteLine($"Encoded: {encoded}");
                Console.WriteLine($"Decoded: {decoded}");
                Console.ReadKey(true);
            }
            static string Encode(string text)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                using (MemoryStream inms = new MemoryStream(bytes))
                {
                    using (MemoryStream outms = new MemoryStream())
                    {
                        using (DeflaterOutputStream dos = new DeflaterOutputStream(outms))
                        {
                            inms.CopyTo(dos);
                            dos.Finish();
                            byte[] encoded = outms.ToArray();                                              
                            return Convert.ToBase64String(encoded);
                        }
                    }
                }
            }
            static string Decode(string base64)
            {
                byte[] bytes = Convert.FromBase64String(base64);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    using (InflaterInputStream iis = new InflaterInputStream(ms))
                    {
                        using (StreamReader sr = new StreamReader(iis))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
