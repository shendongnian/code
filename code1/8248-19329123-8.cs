    private void TestMethod ()
    {
        Action<Exception> errorHandler = ( ex ) => {
            // write to a log, whatever...
        };
        try
        {
            // try some stuff
        }
        catch ( FormatException  ex ) { errorHandler ( ex ); }
        catch ( OverflowException ex ) { errorHandler ( ex ); }
        catch ( ArgumentNullException ex ) { errorHandler ( ex ); }
    }
