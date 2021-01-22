            for (int j = 0; j < 10; j++)
            {
                Stopwatch w = new Stopwatch();
                w.Start();
                try { 
                    double d1 = 0; 
                    for (int i = 0; i < 10000000; i++) { 
                        d1 = Math.Sin(d1);
                        d1 = Math.Sin(d1); 
                    } 
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString()); 
                }
                finally { 
                    //d1 = Math.Sin(d1); 
                }
                w.Stop(); 
                Console.Write("   try/catch/finally: "); 
                Console.WriteLine(w.ElapsedMilliseconds); 
                w.Reset(); 
                w.Start(); 
                double d2 = 0; 
                for (int i = 0; i < 10000000; i++) { 
                    d2 = Math.Sin(d2);
                    d2 = Math.Sin(d2); 
                } 
                w.Stop(); 
                Console.Write("No try/catch/finally: "); 
                Console.WriteLine(w.ElapsedMilliseconds); 
                Console.WriteLine();
            }
