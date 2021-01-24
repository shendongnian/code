     private void RunTestCleanupMethod(object classInstance, TestResult result)
    {
      MethodInfo methodInfo = this.Parent.TestCleanupMethod;
      try
      {
        try
        {
          if (methodInfo != null)
            methodInfo.InvokeAsSynchronousTask(classInstance, (object[]) null);
          Queue<MethodInfo> methodInfoQueue = new Queue<MethodInfo>((IEnumerable<MethodInfo>) this.Parent.BaseTestCleanupMethodsQueue);
          while (methodInfoQueue.Count > 0)
          {
            methodInfo = methodInfoQueue.Dequeue();
            if (methodInfo != null)
              methodInfo.InvokeAsSynchronousTask(classInstance, (object[]) null);
          }
        }
        finally
        {
          (classInstance as IDisposable)?.Dispose();
        }
      }
