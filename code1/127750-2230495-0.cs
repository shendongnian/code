      static void TestExists()
         {
         Stopwatch sw = Stopwatch.StartNew();
         for ( int i = 0; i < 1000; i++ )
            {
            if ( !File.Exists( @"c:\tmp\tmp" + i.ToString() + ".tmp" ) )
               Console.WriteLine( "File does not exist" );
            }
         Console.WriteLine( "Total for exists: " + sw.Elapsed );
         sw = Stopwatch.StartNew();
         for ( int i = 0; i < 1000; i++ )
            {
            if ( File.Exists( @"c:\tmp\tmp_" + i.ToString() + ".tmp" ) )
               Console.WriteLine( "File exists" );
            }
         Console.WriteLine( "Total for not exists: " + sw.Elapsed );
         }
