    // Extend IDisposable for use with using
    class AutoReaderWriterLockSlim : IDisposable {
    	ReaderWriterLockSlim locker;
    	bool disposed = false; // Do not unlock twice, prevent possible misuse
    	// private constructor, this ain't the syntax we want.
    	AutoReaderWriterLockSlim(ReaderWriterLockSlim locker) {
    		this.locker = locker;
    		locker.EnterReadLock();
    	}
    	void IDisposable.Dispose() { // Unlock when done
    		if(disposed) return;
    		disposed = true;
    		locker.ExitReadLock();
    	}
    }
    // The exposed API
    public static class ReaderWriterLockSlimExtensions {
    	public static IDisposable Auto(this ReaderWriterLockSlim locker) {
    	    return new AutoReaderWriterLockSlim(locker);
    	}
    }
