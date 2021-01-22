            dynamic myobj = new ExpandoObject();
            myobj.FirstName = "John";
            myobj.LastName = "Smith";
            SayHello(myobj);
            ...........
            public static void SayHello(dynamic properties)
            {
               Console.WriteLine(properties.FirstName + " " + properties.LastName);
            }
