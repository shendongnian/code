    public static void Log(string message) {
    	LogManager._SynchronizedQueue.Enqueue(message);
    	ThreadPool.QueueUserWorkItem(LogManager.Write(null));
    }
    // QueueUserWorkItem accepts a WaitCallback that requires an object parameter
    private static void Write(object data) {
        // This ensures only one thread can write at a time, but it's dangerous
    	lock(LogManager._WriteLock) {
    		string message = (string)LogManager._SynchronizedQueue.Dequeue();
    		if (message != null) {
    			// Your file writing logic here
    		}
    	}
    }
