    public class Sample
    {
        public void LoadControl( ControlDestination controlDestination, string filename, object parameter )
        {
            HandleExceptions( HandleException, () =>
            {
                //.... your code
            } );
        }
        private void HandleExceptions( Action<Exception> handler, Action code )
        {
            try
            {
                code();
            }
            catch ( FileNotFoundException e )
            {
                handler( e );
            }
            catch ( ArgumentNullException e )
            {
                handler( e );
            }
            catch ( HttpException e )
            {
                handler( e );
            }
            catch ( IncorrectInheritanceException e )
            {
                handler( e );
            }
        }
        private void HandleException( Exception exception )
        {
            // ....
        }
    }
