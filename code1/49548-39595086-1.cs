    internal class ReentrancyInfo
    {
      public WeakReference<object> ReentrantObject { get; set;}
      public object GetReentrantObject() {
        return this.ReentrantObject?.TryGetTarget();
      }
      public DateTime LastCall { get; set;}
      public int StaleMilliseconds { get; set;}
      public int ReentrancyCount { get; set;}
      public bool IsDeadOrStale() {
        bool r = false;
        if (this.LastCall.MillisecondsBeforeNow() > this.StaleMilliseconds) {
          r = true;
        } else if (this.GetReentrantObject() == null) {
          r = true;
        }
        return r;
      }
      public ReentrancyInfo(object reentrantObject, int staleMilliseconds = 1000)
      {
        this.ReentrantObject = new WeakReference<object>(reentrantObject);
        this.StaleMilliseconds = staleMilliseconds;
        this.LastCall = DateTime.Now;
      }
      public bool HandlePotentiallyRentrantCall(object target, int maxOK) {
        bool r = false;
        object myTarget = this.GetReentrantObject();
        if (target.DoesEqual(myTarget)) {
          DateTime last = this.LastCall;
          int ms = last.MillisecondsBeforeNow();
          if (ms > this.StaleMilliseconds) {
            this.ReentrancyCount = 1;
          }
          else {
            if (this.ReentrancyCount == maxOK) {
              throw new Exception("Probable infinite recursion");
            }
            this.ReentrancyCount++;
          }
        }
        this.LastCall = DateTime.Now;
        return r;
      }
    }
    public static class DateTimeAdditions
    {
      public static int MillisecondsBeforeNow(this DateTime time) {
        DateTime now = DateTime.Now;
        TimeSpan elapsed = now.Subtract(time);
        int r;
        double totalMS = elapsed.TotalMilliseconds;
        if (totalMS > int.MaxValue) {
          r = int.MaxValue;
        } else {
          r = (int)totalMS;
        }
        return r;
      }
    }
    public static class WeakReferenceAdditions {
      /// <summary> returns null if target is not available. </summary>
      public static TTarget TryGetTarget<TTarget> (this WeakReference<TTarget> reference) where TTarget: class 
      {
        TTarget r = null;
        if (reference != null) {
          reference.TryGetTarget(out r);
        }
        return r;
      }
    }
