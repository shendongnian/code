      public static void ReaderToString( IDataReader Reader )
         {
         while ( Reader.Read() )
            {
            StringBuilder str = new StringBuilder();
            for ( int i = 0; i < Reader.FieldCount; i++ )
               {
               if ( Reader.IsDBNull( i ) )
                  str.Append( "null" );
               else
                  str.Append( Reader.GetValue( i ).ToString() );
               if ( i < Reader.FieldCount - 1 )
                  str.Append( ", " );
               }
            // do something with the string here
            Console.WriteLine(str);
            }
         }
