    public MyViewModel()
    	: this( null ) {
    }
    
    public MyViewModel( Dispatcher dispatcher = null ) {
    	this._dispatcher = dispatcher ?? Dispatcher.CurrentDispatcher;
    }
