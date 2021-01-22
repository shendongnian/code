    public class ConnectionStateChangedEventArgs : EventArgs
    {
    	public bool IsConnected {get;set;}
    }
    
    interface IConnectionManagerINPC : INotifyPropertyChanged
    {
    	string Name {get;}
    	int ConnectionsLimit {get;}
    	/*
    	
    	A few more properties
    	
    	*/
    	bool IsConnected {get;}
    }
    
    interface IConnectionManager
    {
    	string Name {get;}
    	int ConnectionsLimit {get;}
    	/*
    	
    	A few more properties
    	
    	*/
    	event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged;
    	bool IsConnected {get;}
    }
