    namespace StreamReadWebRequest
    {
        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Net;
        using System.IO;
    
        class Program
        {
            static void Main(string[] args)
            {
                HttpWebRequest req;
                HttpWebResponse res = null;
    
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(
                            "http://cdimage.debian.org/debian-cd/5.0.4/i386/iso-cd/debian-504-i386-CD-1.iso");
                    res = (HttpWebResponse)req.GetResponse();
                    Stream stream = res.GetResponseStream();
    
                    byte[] data = new byte[4096];
                    int read;
                    while ((read = stream.Read(data, 0, data.Length)) > 0)
                    {
                        Process(data, read);
                    }
                }
                finally
                {
                    if (res != null)
                        res.Close();
                }
                Console.In.Read();
            }
    
            private static void Process(byte[] data, int read)
            {
                Console.Out.Write(ASCIIEncoding.ASCII.GetString(data));
            }
        }
    }
