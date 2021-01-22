    var dict1 = TryCatch(
      () => 
          data1.ToDictionary(dim => new { 
             Value1 = dim.Val1,
             Value2 = dum.Val2
          }
      , (ArgumentException ex) => {
          Console.WriteLine("Duplicate values in Data1 {0}", ex);
         // throw(ex) works as well, and shouldn't screw the callstack up much
         // But I happen to like making it explicit
         return false; 
      }
    );
    static TResult TryCatch<TResult, TException>(Func<TResult> @try, Func<TException, bool> @catch) where TException : Exception {
       try {
           return @try();
       } catch (Exception ex) {
           TException tEx = ex as TException;
           if (tEx != null && @catch(ex)) {
              // handled
           } else {
              throw;
           } 
       }
    }
