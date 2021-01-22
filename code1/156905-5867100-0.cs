    /// <summary>
    /// KVV 20110502
    /// Fix for bug in Unity throwing a synchronizedlockexception at each register
    /// </summary>
    class LifeTimeManager : ContainerControlledLifetimeManager
    {
        protected override void SynchronizedSetValue(object newValue)
        {
            base.GetValue();
            base.SynchronizedSetValue(newValue);
        }
    }
