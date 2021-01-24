    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                      "redis",
                      "redis:6379",
                      "10.0.0.72",
                      "10.0.0.72:6379",
                      "my.domain.name",
                      "my.domain.name:6379"
                };
                string address = "";
                string port = "";
                foreach (string input in inputs)
                {
                    if (input.Contains(":"))
                    {
                        address = input.Substring(0, input.IndexOf(":"));
                        port = input.Substring(input.IndexOf(":") + 1);
                    }
                    else
                    {
                        address = input;
                        port = "";
                    }
                    Console.WriteLine("Address : '{0}'; Port : '{1}'", address, port);
                }
                Console.ReadLine();
            }
        }
    }
