    using System;
    using System.IO;
    using RazorEngine;
    using RazorEngine.Templating;
    namespace RazorDemo1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string template = File.ReadAllText("./Templates/Person.cshtml");
                var person = new Person
                {
                    FirstName = "Rui",
                    LastName = "Jarimba"
                };
                string html = Engine.Razor.RunCompile(template, "templateKey", typeof(Person), person);
                Console.WriteLine(html);
            }
        }
    }
