    public class BaseClass {
        public void Method() // Non-virtual
        {
              // Do required work
              // Call virtual method now...
              this.OnMethod();
        }
        protected virtual void OnMethod()
        { // Do nothing
        }
     }
