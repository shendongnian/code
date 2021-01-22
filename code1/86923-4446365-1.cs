    public class ConnectionManager {
    	private const int _maxConnections = 4;
    
    	private Semaphore _semaphore = new Semaphore(_maxConnections, _maxConnections);
    	private Stack<string> _groupNames = new Stack<string>();
    
    	public string ObtainConnectionGroupName() {
    		_semaphore.WaitOne();
    		return GetConnectionGroupName();
    	}
    
    	public void ReleaseConnectionGroupName(string name) {
    		lock (_groupNames) {
    			_groupNames.Push(name);
    		}
    		_semaphore.Release();
    	}
    
    	public string SwapForFreshConnection(string name, Uri uri) {
    		ServicePoint servicePoint = ServicePointManager.FindServicePoint(uri);
    		servicePoint.CloseConnectionGroup(name);
    		return GetConnectionGroupName();
    	}
    
    	private string GetConnectionGroupName() {
    		lock (_groupNames) {
    			return _groupNames.Count != 0 ? _groupNames.Pop() : Guid.NewGuid().ToString();
    		}
    	}
    }
