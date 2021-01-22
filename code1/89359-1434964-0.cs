    var dict1 = TryCatch(
      () => 
          data1.ToDictionary<ArgumentException>(dim => new { 
             Value1 = dim.Val1,
             Value2 = dum.Val2
          }
      , ex => {
          Console.WriteLine("Duplicate values in Data1 {0}", ex);
         // throw may work - but I;ll be safe and use a bool to indicate rethrow
         return false; 
      }
    );
    static TResult TryCatch<TResult, TException>(Func<TResult> @try, Func<TException, bool> @catch) where TException : Exception {
       try {
           return @try();
       } catch (Exception ex) {
           if (ex is TException && @catch(ex)) {
              // handled
           } else {
              throw;
           } 
       }
    }
