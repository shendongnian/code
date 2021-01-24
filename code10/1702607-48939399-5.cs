    try { ... }
    catch(ParsingException e) // Will still catch IdNumberNONEParsingException
    {
        if (e is IdNumberNONEParsingException) // Checks if the exception that was thrown was an IdNumberNONEParsingException
        {
            // Special logic for handling IdNumberNONEParsingException
        }
        else
        {
            // Special logic for handling non-IdNumberNONEParsingExceptions
        }
        // Shared logic for handling all types of ParsingExceptions eg. logging, cleanup, etc.
    }
