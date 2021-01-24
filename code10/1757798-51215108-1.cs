      //Conversion
      public static List<fooGridViewModel> ToGridViewModels(this IQueryable<fooSource> source)
      {
          List<fooSource> results = source.ToList();    // send SQL to database, load results
          
          return results.ProjectTo<fooGridViewModel>(); // convert results to view-model
                       
      }
