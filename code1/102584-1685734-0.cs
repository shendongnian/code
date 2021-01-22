    Connection AcquireConnection (string user)
    {
          lock (user) {
              Cache cache = HttpRuntime.Cache;
              string key = user + "@@@ConnectionInUse";
              if (cache [key] != null) {
                   Monitor.Wait (user, true); // TODO: check return value!
              }
              cache [key] = key;
              return OpenConnection ();
          }
    }
    void ReleaseConnection (string user)
    {
         lock (user) {
             Cache cache = HttpRuntime.Cache;
             string key = user + "@@@ConnectionInUse";
             cache.Remove (key);
             Monitor.Pulse (user);
         }
    }
