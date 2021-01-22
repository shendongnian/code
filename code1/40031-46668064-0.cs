`
    public abstract class LockResult {
        internal LockResult() {
        }
    }
    public sealed class LockSucceededResult : LockResult {
        //Info for when a lock succeeded
    }
    public sealed class LockFailedResult : LockResult {
        //Info for when a lock failed
    }
`
