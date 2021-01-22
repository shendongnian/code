    internal class Foo
    {
       private Object lockObject = new Object();
       private void ChangeVars()
       {
          lock (this.lockObject)
          {
             // Manipulate the state.
          }
       }
    }
