    public static void Locking(Action action) {
      Lock();
      try {
        action();
      } finally {
        Unlock();
      }
    }
    LocalConnection.Locking( () => {...});
