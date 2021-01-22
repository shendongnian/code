    public static class ExceptionExtensions {
        private static logger = new Logger();
        public static Exception LogIfFailure( this Exception e ) {
            if( e != null )
                logger.Write( e.Message );
            return e;
        }
        public static Exception ShowDialogIfFailure( this Exception e ) {
            if( e != null )
                MessageBox.Show( e.Message );
            return e;
        }
    }
