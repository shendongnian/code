            var anonType = new
            {
                FirstName = "James",
                LastName = "Bond",
                FullName = new Action<string, string>(
                    (x, y) =>
                        { 
                            Console.WriteLine(x + y );
                        })                
            };
                        
            anonType.FullName("Roger","Moore");
