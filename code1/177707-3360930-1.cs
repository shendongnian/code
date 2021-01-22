            //Declare object x of type SomeClass.
            SomeClass x;
            //Instantiate the object by calling the constructor.
            x = new SomeClass("c:/temp/test.txt");
            try
            {
                //Do some work on x.
            }
            finally
            {
                if(x != null)
                    x.Dispose();
            }
