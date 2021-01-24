     IEnumerator<Statement> searchResults;
     void NextResult()
     {
         if (searchResults == null)
             searchResults = Search( /* parameters...*/).GetEnumerator();
          if (!searchResults.MoveNext())
         {
             // In this situation we have reached and of the tree
             // Restart from the beginning
             searchResults.Reset();
             searchResults.MoveNext();
         }
         var statement = searchResults.Current;
         if (statement != null)
         {
             // ...
             // Actions regarding current statement
             // ...
         }
     }
