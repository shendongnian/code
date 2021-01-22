    class B
        {
            List<A> myList;
            public B() {
              var a = new A();
              a.SomeDelegate = ( x => Console.WriteLine("SomeFunction " + x) );
              myList = new List<A>();
              myList.Add(a);               // add wrapper object instead of delegate to list
                SerialInvokeDelegates();   // will invoke SomeFunction
              
              a.SomeDelegate = (x => Console.WriteLine("AnotherFunction " + x));
                SerialInvokeDelegates();   // will invoke AnotherFunction
            }
    
            private void SerialInvokeDelegates()
            {
                Console.WriteLine("Invoking all delegates in B's List");
                foreach (var a in myList)
                    a.SomeDelegate(Guid.NewGuid());
            }
        }
