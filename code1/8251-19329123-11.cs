    // super sucks...
    catch( Exception ex )
    {
        if ( ex is FormatException || ex is OverflowException || ex is ArgumentNullException )
        {
            // write to a log, whatever...
            return;
        }
        throw;
    }
