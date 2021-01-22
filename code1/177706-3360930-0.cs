            //Declare object x of type SomeClass.
            SomeClass x;
            try
            {
                //Instantiate the object by calling the constructor.
                x = new SomeClass("c:/temp/test.txt");
                //Do some work on x.
            }
            finally
            {
                if(x != null)
                    x.Dispose();
            }
