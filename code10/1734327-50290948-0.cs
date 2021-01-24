     while( true )
        {
          if( Console.KeyAvailable ) // since .NET 2.0
          {
            char c = Console.ReadKey().KeyChar ;
            Console.Write( c );
          }
        }
