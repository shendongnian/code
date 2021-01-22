            Base b = new Base();
            Derived d = new Derived();
            if (typeof(Base).IsInstanceOfType(b)) 
                Console.WriteLine("b can come in.");    // will be printed
            if (typeof(Base).IsInstanceOfType(d)) 
                Console.WriteLine("d can come in.");    // will be printed
