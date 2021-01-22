     public static void EnumerateAllSuitsDemoMethod()
            {
                var foos= GetValues<Suit>(); // custom method
                foreach(var foo in foos)
                {
                    //Do something
                }
            }
