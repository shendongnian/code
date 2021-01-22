            // goto
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    goto Foo; // yeuck!
                }
            }
        Foo:
            Console.WriteLine("Hi");
            // anon-method
            Action work = delegate
            {
                for (int x = 0; x < 100; x++)
                {
                    for (int y = 0; y < 100; y++)
                    {
                        return; // exits anon-method
                    }
                }
            };
            work(); // execute anon-method
            Console.WriteLine("Hi");
