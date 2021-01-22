    public static class RecorderScope
    {
       public static void Wrap(Recorder recorder, Action action, 
          Action<T1> exHandler1)
          where T1: Exception
       {
          Recorder recorder = Recorder.StartTiming();
          try
          {
             action();
          }
          catch(T1 ex1)
          {
             exHandler1(ex1);
          }
          finally
          {
             recorder.Stop();
          }
       }
    }
