    public class MyClass {
    
    	private delegate void AsyncDoSomethingCaller();
    	private delegate void AsyncDoDisposeCaller();
    
    	private int pendingTasks = 0;
    	private readonly object lockObj = new object();
    	
    	public DoSomething() {
    		// Do whatever.
    	}
    	
    	public AsyncDoSomething() {
    		lock ( lockObj ) {
    			pendingTasks++;
    			AsyncDoSomethingCaller caller = new AsyncDoSomethingCaller();
    			caller.BeginInvoke( new AsyncCallback( EndDoSomethingCallback ), caller);
    		}
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
    			lock ( lockObj ) {
    				if ( pendingTasks == 0 ) {
    					return;
    				}
    			}
    			// Allow other threads to execute.
    			Thread.Sleep( 0 );
    		}
    	}
    	
    	private void EndDoSomethingCallback( IAsyncResult ar ) {
    		lock ( lockObj ) {
    			AsyncDoSomethingCaller caller = (AsyncDoSomethingCaller) ar.AsyncState;
    			caller.EndInvoke( ar );
    			pendingTasks--;
    		}
    	}
    	
    	private void EndDoDisposeCallback( IAsyncResult ar ) {
    		AsyncDoDisposeCaller caller = (AsyncDoDisposeCaller) ar.AsyncState;
    		caller.EndInvoke( ar );
    	}
    }
