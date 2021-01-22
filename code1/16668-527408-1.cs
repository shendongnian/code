    unsafe {
      int * sp = stackalloc int[1];
      try {
        return a+b;
      }
      finally {
        Trace.WriteLine("return is " + *(sp+3));
      }
    }
