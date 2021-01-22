   public static void PrintKeysAndValues( Hashtable myList )  {
      IDictionaryEnumerator myEnumerator = myList.GetEnumerator();
      Console.WriteLine( "\t-KEY-\t-VALUE-" );
      while ( myEnumerator.MoveNext() )
         Console.WriteLine("\t{0}:\t{1}", myEnumerator.Key, myEnumerator.Value);
      Console.WriteLine();
   }
