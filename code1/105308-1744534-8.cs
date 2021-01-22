    public static class RecorderScope
    {
       public static void Wrap(Action<Recorder> action, 
          Action<Recorder, T1> exHandler1)
          where T1: Exception
       {
          Recorder recorder = Recorder.StartTiming();
          try
          {
             action(recorder);
          }
          catch(T1 ex1)
          {
             exHandler1(recorder, ex1);
          }
          finally
          {
             recorder.Stop();
          }
       }
    }
