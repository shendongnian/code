ReaderWriterLockSlim myLock = new ReaderWriterLockSlim();
try
{
    myLock.EnterReadLock();
    // Do stuff
}
finally
{
    // Release the lock
    myLock.ExitReadLock();
}
A wrapper [class][2] like the one in the accepted answer would be:
  /// <summary>
  /// Manager for a lock object that acquires and releases the lock in a manner
  /// that avoids the common problem of deadlock within the using block
  /// initialisation.
  /// </summary>
  /// <remarks>
  /// This manager object is, by design, not itself thread-safe.
  /// </remarks>
  public sealed class ReaderWriterLockMgr : IDisposable
  {
    /// <summary>
    /// Local reference to the lock object managed
    /// </summary>
    private ReaderWriterLockSlim _readerWriterLock = null;
    private enum LockTypes { None, Read, Write, Upgradeable }
    /// <summary>
    /// The type of lock acquired by this manager
    /// </summary>
    private LockTypes _enteredLockType = LockTypes.None;
    /// <summary>
    /// Manager object construction that does not acquire any lock
    /// </summary>
    /// <param name="ReaderWriterLock">The lock object to manage</param>
    public ReaderWriterLockMgr(ReaderWriterLockSlim ReaderWriterLock)
    {
      if (ReaderWriterLock == null)
        throw new ArgumentNullException("ReaderWriterLock");
      _readerWriterLock = ReaderWriterLock;
    }
    /// <summary>
    /// Call EnterReadLock on the managed lock
    /// </summary>
    public void EnterReadLock()
    {
      if (_readerWriterLock == null)
        throw new ObjectDisposedException(GetType().FullName);
      if (_enteredLockType != LockTypes.None)
        throw new InvalidOperationException("Create a new ReaderWriterLockMgr for each state you wish to enter");
      // Allow exceptions by the Enter* call to propogate
      // and prevent updating of _enteredLockType
      _readerWriterLock.EnterReadLock();
      _enteredLockType = LockTypes.Read;
    }
    /// <summary>
    /// Call EnterWriteLock on the managed lock
    /// </summary>
    public void EnterWriteLock()
    {
      if (_readerWriterLock == null)
        throw new ObjectDisposedException(GetType().FullName);
      if (_enteredLockType != LockTypes.None)
        throw new InvalidOperationException("Create a new ReaderWriterLockMgr for each state you wish to enter");
      // Allow exceptions by the Enter* call to propogate
      // and prevent updating of _enteredLockType
      _readerWriterLock.EnterWriteLock();
      _enteredLockType = LockTypes.Write;
    }
    /// <summary>
    /// Call EnterUpgradeableReadLock on the managed lock
    /// </summary>
    public void EnterUpgradeableReadLock()
    {
      if (_readerWriterLock == null)
        throw new ObjectDisposedException(GetType().FullName);
      if (_enteredLockType != LockTypes.None)
        throw new InvalidOperationException("Create a new ReaderWriterLockMgr for each state you wish to enter");
      // Allow exceptions by the Enter* call to propogate
      // and prevent updating of _enteredLockType
      _readerWriterLock.EnterUpgradeableReadLock();
      _enteredLockType = LockTypes.Upgradeable;
    }
    /// <summary>
    /// Exit the lock, allowing re-entry later on whilst this manager is in scope
    /// </summary>
    /// <returns>Whether the lock was previously held</returns>
    public bool ExitLock()
    {
      switch (_enteredLockType)
      {
        case LockTypes.Read:
          _readerWriterLock.ExitReadLock();
          _enteredLockType = LockTypes.None;
          return true;
        case LockTypes.Write:
          _readerWriterLock.ExitWriteLock();
          _enteredLockType = LockTypes.None;
          return true;
        case LockTypes.Upgradeable:
          _readerWriterLock.ExitUpgradeableReadLock();
          _enteredLockType = LockTypes.None;
          return true;
      }
      return false;
    }
    /// <summary>
    /// Dispose of the lock manager, releasing any lock held
    /// </summary>
    public void Dispose()
    {
      if (_readerWriterLock != null)
      {
        ExitLock();
        // Tidy up managed resources
        // Release reference to the lock so that it gets garbage collected
        // when there are no more references to it
        _readerWriterLock = null;
        // Call GC.SupressFinalize to take this object off the finalization
        // queue and prevent finalization code for this object from
        // executing a second time.
        GC.SuppressFinalize(this);
      }
    }
    protected ~ReaderWriterLockMgr()
    {
      if (_readerWriterLock != null)
        ExitLock();
      // Leave references to managed resources so that the garbage collector can follow them
    }
  }
Making usage as follows:
ReaderWriterLockSlim myLock = new ReaderWriterLockSlim();
using (ReaderWriterLockMgr lockMgr = new ReaderWriterLockMgr(myLock))
{
    lockMgr.EnterReadLock();
    // Do stuff
}
Also, from [Joe Duffy's Blog][3]
> Next, the lock is not robust to asynchronous exceptions such as thread aborts and out of memory conditions.  If one of these occurs while in the middle of one of the lock’s methods, the lock state can be corrupt, causing subsequent deadlocks, unhandled exceptions, and (sadly) due to the use of spin locks internally, a pegged 100% CPU.  So if you’re going to be running your code in an environment that regularly uses thread aborts or attempts to survive hard OOMs, you’re not going to be happy with this lock. 
  [1]: http://web.archive.org/web/20120323190453/http://www.nobletech.co.uk/Articles/ReaderWriterLockMgr.aspx
  [2]: https://social.msdn.microsoft.com/Forums/pt-BR/60fa5522-4ac2-4395-9d5f-d001fdce09fd/thread-safe-classe-gerente-de-readerwriterlockslim-erro-de-compilacao?forum=vscsharppt
  [3]: http://web.archive.org/web/20120113121354/http://www.bluebytesoftware.com/blog/PermaLink,guid,c4ea3d6d-190a-48f8-a677-44a438d8386b.aspx
