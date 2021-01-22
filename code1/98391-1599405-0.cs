            try
            {
                if( !doSomething )
                {
                    Console.WriteLine ("not dosomething");
                    return;
                }
                if( !doSomething2 )
                {
                    Console.WriteLine ("not dosomething 2");
                    return;
                }
            }
            finally
            {
                Console.WriteLine ("In finally");
            }
