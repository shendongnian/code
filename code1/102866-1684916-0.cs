    public interface ISubService
    {
       void Initialize( XmlElement xmlSection );
       bool Start( );
       void RequestStop( );
       void Stop( TimeSpan timeout );
    }
