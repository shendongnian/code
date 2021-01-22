    static List<bool> ToBool(FormCollection form) { // couldn't find the type on MSDN
        List<bool> result = new List<Bool>();
        foreach (object o in form) {
             if (o == null) {
                 result.Add(false);
             }
             else {
                 if (o is bool) {
                     result.Add((bool)o);
                 }
                 else {
                    // do whatever other conversion
                    result.Add(true); // probably the wrong thing - depends on what you're testing
                 }
             }
         }
         return result;
    }
