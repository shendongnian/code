    using System;
    
    namespace delegates
    {
        class Program
        {
            // An event which you set up by attaching handlers (delegates)
            // and then running using the Invoke() method.
            private EventHandler<EventArgs> _event;
    
            void SetupFoo()
            {
                // Attach the function foo to the _event
                _event += Foo;
            }
    
            void SetupBar()
            {
                // Attach a delegate (aka anonymous method) to the _event
                _event += delegate { Console.WriteLine("Bar is called"); };
            }
            
            void SetupBaz()
            {
                // Attach a lambda to the _event
                _event += (sender, e) => Console.WriteLine("Baz is called");
            }
    
            void Fire()
            {
                // Run all the attached methods/delegates/lambdas
                _event.Invoke(this, EventArgs.Empty); 
            }
    
    
            static void Main(string[] args)
            {
                var prog = new Program();
                prog.SetupFoo();
                prog.SetupBar();
                prog.SetupBaz();
                prog.Fire();
                Console.ReadKey();
            }
    
            private static void Foo(object sender, EventArgs e)
            {
                Console.WriteLine("Foo is called");
            }
        }
    }
