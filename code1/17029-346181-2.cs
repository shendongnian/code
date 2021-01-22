    using (lock.GetUpgradeableReadLock())
    {
      // try read
      using (lock.GetWriteLock())
      {
        //do write
      }
    }
