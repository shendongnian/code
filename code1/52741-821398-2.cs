    using System;
    using IronRuby;
    using IronRuby.Runtime;
    using Microsoft.Scripting.Hosting;
    class App
    {
        static void Main()
        {
            var setup = new ScriptRuntimeSetup();
            setup.LanguageSetups.Add(
                new LanguageSetup(
                    typeof(RubyContext).AssemblyQualifiedName,
                    "IronRuby",
                    new[] { "IronRuby" },
                    new[] { ".rb" }
                )
            );
            var runtime = new ScriptRuntime(setup);
            var engine = runtime.GetEngine("IronRuby");
            var ec = Ruby.GetExecutionContext(runtime);
            ec.DefineGlobalVariable("bob", new Person
            {
                Name = "Bob",
                Age = 30,
                Weight = 213,
                FavouriteDay = "1/1/2000"
            });
            var eval = engine.Execute<bool>(
                "return ($bob.Age > 3 && $bob.Weight > 50) || $bob.Age < 3"
            );
            Console.WriteLine(eval);
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string FavouriteDay { get; set; }
    }
