    public static void PrintValues2( StringCollection myCol )  {
          StringEnumerator myEnumerator = myCol.GetEnumerator();
          while ( myEnumerator.MoveNext() )
             Console.WriteLine( "   {0}", myEnumerator.Current );
          Console.WriteLine();
       }
