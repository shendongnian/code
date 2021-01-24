      public void FireAndForget(this Task task)
      {
        // access exception (and ideally log it) to avoid a potential exception being rethrown by the finalizer as an unobserved exception
        task.ContinueWith(t => Debug.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
      }
    }
