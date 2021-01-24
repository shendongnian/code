      //Conversion
      public static List<fooGridViewModel> ToGridViewModels(this IQueryable<fooSource> source)
      {
          return source.ProjectTo<fooGridViewModel>()
                       .ToList();   // send SQL to database, load results
      }
