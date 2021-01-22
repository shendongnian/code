    // subscribe to an event
    eventsource.AddHandler( "foo", MyEventHandler );
    
    // unsubscribe
    eventsource.RemoveHandler( "foo", MyEventHandler );
    
    // raise event for id
    eventsource.RaiseEvent( "foo" );
    public class EventSource
    {
    	Dictionary<string,List<EventHandler>> handlers = new Dictionary<string,List<EventHandler>>();
    
    	public void AddHandler( string id, EventHandler handler )
    	{
    		if (!handlers.ContainsKey( id )) {
    			handlers[id] = new List<EventHandler>();
    		}
    		handlers[id].Add( handler );
    	}
    
    	public void RemoveHandler( string id, EventHandler handler )
    	{
    		if (handlers.ContainsKey( id )) {
    			handlers[id].Remove( handler );
    		}
    	}
    
    	public void RaiseEvent( string id )
    	{
    		if (handlers.ContainsKey( id )) {
    			foreach( var h in handlers[id] ) {
    				h( this, EventArgs.Empty );
    			}
    		}		
    	}
    }
