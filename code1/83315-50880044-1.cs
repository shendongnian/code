        static void Main()
        {
            var anonWithoutContext = Test();
            var nowTheresMyContext = new SomeContext();
            anonWithoutContext.Fire(nowTheresMyContext);
            Console.WriteLine(nowTheresMyContext.Stuff[0]);
            
        }
