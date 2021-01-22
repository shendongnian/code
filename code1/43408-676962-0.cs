    using System;
    using System.IO;
    using System.Text;
    class Program
        {
            private static FileStream stream;
            static void Main(string[] args)
            {
                stream = new FileStream("foo.txt", 
                                        FileMode.Create, 
                                        FileAccess.Write);
    
                const string mystring = "Foobarlalala";
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(mystring);
                Console.WriteLine("Started writing");
                stream.BeginWrite(data, 0, data.Length, callback, null);
                Console.WriteLine("Writing dispatched, sleeping 5 secs");
                System.Threading.Thread.Sleep(5000);
            }
    
            public static void callback(IAsyncResult ia)
            {
                stream.EndWrite(ia);
                Console.WriteLine("Finished writing");
            }
        }
    }
