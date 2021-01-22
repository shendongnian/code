    using RazorEngine;
    using RazorEngine.Templating;
    using System;
    
    namespace RazorEngineTest
    {
        class Program
        {
            static void Main(string[] args)
            {
        string template =
        @"<h1>Heading Here</h1>
    Dear @Model.UserName,
    <br />
    <p>First part of the email body goes here</p>";
    
        const string templateKey = "tpl";
    
        // Better to compile once
        Engine.Razor.AddTemplate(templateKey, template);
        Engine.Razor.Compile(templateKey);
    
        // Run is quicker than compile and run
        string output = Engine.Razor.Run(
            templateKey, 
            model: new
            {
                UserName = "Fred"
            });
    
        Console.WriteLine(output);
            }
        }
    }
