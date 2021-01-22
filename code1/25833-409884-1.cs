    // throws NumberNotHexidecimalException
    int ParseHexidecimal(string numberToParse); 
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
             // Implement the error policy for unexpected exceptions:
             // log a callstack, assert if a debugger is attached etc.
             LogRetailAssert(ex);
             // rethrow the exception
             // The downside is that a JIT debugger will have the next
             // line as the place that threw the exception, rather than
             // the original location further down the stack.
             throw;
             // A better practice is to use an exception filter here.
             // see the link to Exception Filter Inject above
             // http://code.msdn.microsoft.com/ExceptionFilterInjct
         }
    }
