      public static bool TryReadLine(out string line, int timeOutMillisecs = Timeout.Infinite) {
        getInput.Set();
        bool success = gotInput.WaitOne(timeOutMillisecs);
        if (success)
          line = input;
        else
          line = null;
        return success;
      }
