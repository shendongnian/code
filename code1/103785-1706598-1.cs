    private void HandleExceptions( Action<Exception> handler, Action code )
        {
            try
            {
                code();
            }
            catch ( Exception e )
            {
                if ( e is FileNotFoundException
                    || e is ArgumentNullException
                    || e is HttpException
                    || e is IncorrectInheritanceException )
                    handler( e );
                else
                    throw;
            }
        }
