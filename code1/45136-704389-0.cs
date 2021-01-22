    public static void ResultCallback(int lineCount) {
      // runs on worker thread
      Invoke((MethodInvoker)delegate {
          // runs on UI thread
          Console.WriteLine(Thread.CurrentThread.Name +
             ":Independent task printed {0} lines.", lineCount);
      });
    }
