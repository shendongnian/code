     var predicate = PredicateBuilder.True<Book>();
     predicate = predicate.And( b => b.Publisher == "O'Reilly" );
     var titlePredicate = PredicateBuilder.False<Book>();
     foreach (var term in searchTerms)
     {
         titlePredicate = titlePredicate.Or( b => b.Title.Contains( term ) );
     }
     predicate = predicate.And( titlePredicate );
     
     var books = dc.Book.Where( predicate );
