    public class MyClass : IDisposable {
    
    	private delegate void AsyncDoSomethingCaller();
    	private delegate void AsyncDoDisposeCaller();
    
    	private int pendingTasks = 0;
    	
    	public DoSomething() {
    		// Do whatever.
    	}
    	
    	public AsyncDoSomething() {
    		pendingTasks++;
    		AsyncDoSomethingCaller caller = new AsyncDoSomethingCaller();
    		caller.BeginInvoke( new AsyncCallback( EndDoSomethingCallback ), caller);
    	}
    	
    	public Dispose() {
    		AsyncDoDisposeCaller caller = new AsyncDoDisposeCaller();
    		caller.BeginInvoke( new AsyncCallback( EndDoDisposeCallback ), caller);
    	}
    	
    	private DoDispose() {
    		WaitForPendingTasks();
    		
    		// Finally, dispose whatever managed and unmanaged resources.
    	}
    	
    	private void WaitForPendingTasks() {
    		while ( true ) {
    			// Check if there is a pending task.
    			if ( pendingTasks == 0 ) {
    				return;
    			}
    		
    			// Allow other threads to execute.
    			Thread.Sleep( 0 );
    		}
    	}
    	
    	private void EndDoSomethingCallback( IAsyncResult ar ) {
    		AsyncDoSomethingCaller caller = (AsyncDoSomethingCaller) ar.AsyncState;
    		caller.EndInvoke( ar );
    		pendingTasks--;
    	}
    	
    	private void EndDoDisposeCallback( IAsyncResult ar ) {
    		AsyncDoDisposeCaller caller = (AsyncDoDisposeCaller) ar.AsyncState;
    		caller.EndInvoke( ar );
    	}
    }
