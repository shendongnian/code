    int ParseHexidecimal(string numberToParse); //throws NumberNotHexidecimalException
    bool TryParseHexidecimal(string numberToParse, out int parsedInt)
    {
         try
         {
             parsedInt = ParseHexidecimal(numberToParse);
             return true;
         }
         catch(NumberNotHexidecimalException ex)
         {
             parsedInt = 0;
             return false;
         }
         catch(Exception ex)
         {
             // Implement whatever error policy is in place for unexpected exceptions:
             // log a callstack, assert if a debugger is attached etc.
             LogRetailAssert(ex);
             // rethrow the exception
             // One gigantic downside is that a JIT debugger will have the next line
             // as the place that threw the exception.
             throw;
             // A better practice is to have this clause be an exception filter.
             // see the link to Exception Filter Inject above
             // http://code.msdn.microsoft.com/ExceptionFilterInjct
         }
    }
