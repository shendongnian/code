    class Service : IDisposable
    {
        public DataContext DC= new DataContext();
        public void Dispose( )
        {
            DC.Dispose( );
        }
    }
