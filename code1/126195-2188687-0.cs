            for ( int i = 0; i < 5; i++ )
               {
               Stopwatch timeit = new Stopwatch();
               timeit.Start();
               AdsConnection conn = new AdsConnection( @"Data Source = \\10.24.36.47:6262\testsys\;" );
               conn.Open();
               timeit.Stop();
               Console.WriteLine( "Milliseconds:  " + timeit.ElapsedMilliseconds.ToString() );
               //conn.Close();
               }
