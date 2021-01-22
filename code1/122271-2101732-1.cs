    void UseMeUnlocked(Action callback) {
      Unlock();
      try {
        callback();
      }
      finally {
        Lock();
      }
    }
