    namespace MyNamespace
    {
        using System;
        using System.Reflection;
        using IronRuby.Runtime;
        using Microsoft.Scripting.Hosting;
    
        public class Program
        {
            static void Main(string[] args)
            {
                var setup = new ScriptRuntimeSetup();  
                setup.LanguageSetups.Add(  
                    new LanguageSetup(  
                        typeof(RubyContext).AssemblyQualifiedName,
                        "IronRuby",
                        new [] { "IronRuby" },
                        new [] { ".rb" }
                    )  
                );
                var runtime = new ScriptRuntime(setup);
                runtime.LoadAssembly(Assembly.GetExecutingAssembly());
                var engine = runtime.GetEngine("IronRuby");
                var eval = (bool)engine.Execute(
                    @"require 'MyNamespace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'
                    bob = MyNamespace::Program.GetPerson
                    return (bob.Age > 3 && bob.Weight > 50) || bob.Age < 3"
                );
                Console.WriteLine(eval);
            }
    
            public static Person GetPerson()
            {
                return new Person
                { 
                    Name = "Bob",
                    Age = 30,
                    Weight = 213,
                    FavouriteDay = "1/1/2000" 
                };
            }
    
        }
    
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Weight { get; set; }
            public string FavouriteDay { get; set; }
        }
    }
