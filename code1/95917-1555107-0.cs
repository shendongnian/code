            static void Main()
            {
                Thread t1 = new Thread (AddItems);
                Thread t2 =new Thread (AddItems);
                
                t1.Start (); 
                t2.Start ();
                
                t1.Join ();
                t2.Join ();
    
                foreach( string str in list )
                {
                    Console.WriteLine (str);
                }
                Console.WriteLine ("Count=" + list.Count.ToString ());
                Console.ReadKey (true);
            }
