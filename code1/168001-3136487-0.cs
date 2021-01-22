    public class Fiber
    {
        private readonly Stack<IEnumerator> stackFrame = new Stack<IEnumerator>();
        private IEnumerator currentRoutine;
    
        public Fiber(IEnumerator entryPoint)
        {
            this.currentRoutine = entryPoint;
        }
    
        public bool Step()
        {
            if (currentRoutine.MoveNext())
            {
                var subRoutine = currentRoutine.Current
                               as IEnumerator;
                if (subRoutine != null)
                {
                    stackFrame.Push(currentRoutine);
                    currentRoutine = subRoutine;
                }
            }
            else if (stackFrame.Count > 0)
            {
                currentRoutine = stackFrame.Pop();
            }
            else
            {
              OnFiberTerminated(
                  new FiberTerminatedEventArgs(
                      currentRoutine.Current
                  )
              );
              return false;
          }
    
          return true;
        }
    
        public event EventHandler<FiberTerminatedEventArgs> FiberTerminated;
    
        private void OnFiberTerminated(FiberTerminatedEventArgs e)
        {
            var handler = FiberTerminated;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
    
    public class FiberTerminatedEventArgs : EventArgs
    {
      private readonly object result;
    
      public FiberTerminatedEventArgs(object result)
      {
          this.result = result;
      }
    
      public object Result
      {
          get { return this.result; }
      }
    }   
       
    class FiberTest
    {
      private static IEnumerator Recurse(int n)
      {
          Console.WriteLine(n);
          yield return n;
          if (n > 0)
          {
              yield return Recurse(n - 1);
          }
      }
    
      static void Main(string[] args)
      {
          var fiber = new Fiber(Recurse(5));
          while (fiber.Step()) ;
      }
    }
