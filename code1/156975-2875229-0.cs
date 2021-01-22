    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ConsoleApplication1.ServiceReference1; 
    namespace ConsoleApplication1 
    { 
        class Program 
        { 
            static void Main(string[] args) 
            { 
                Service1Client Proxy=null; 
                try 
                { 
                    Proxy = new Service1Client(); 
                    string res = Proxy.GetData(); 
                    Console.WriteLine(res); 
                    Proxy.Close();       
                } 
                catch 
                { 
                    Proxy.Abort(); 
                } 
                Console.ReadKey(true); 
            } 
        } 
    }
