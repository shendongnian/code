      public class Bar : IDisposable {
         public Bar() {
            DisposeCalled = false;
            
         }
         public void Blah() {
            if (DisposeCalled) {
               // object was disposed you shouldn't use it anymore
               throw new ObjectDisposedException("Object was already disposed.");
            }
         }
         public void Dispose() {
            // give back / free up resources that were used by the Bar object
            DisposeCalled = true;
         }
         public bool DisposeCalled { get; private set; }
      }
      public class ConstructorThrows : IDisposable {
         public ConstructorThrows(int argument) {
            throw new ArgumentException("argument");
         }
         public void Dispose() {
            Log.Info("Constructor.Dispose() called.");
         }
      }
      [Test]
      public void Foo() {
         var bar = new Bar();
         using (bar) {
            bar.Blah(); // ok to call
         }// Upon hitting this closing brace Dispose() will be invoked on bar.
         try {
            bar.Blah(); // Throws ObjectDisposedException
            Assert.Fail();
         }
         catch(ObjectDisposedException) {
            // This exception is expected here
         }
         using (bar = new Bar()) { // can reuse the variable, though
            bar.Blah(); // Fine to call as this is a second instance.
         }
         // The following code demonstrates that Dispose() won't be called if 
         // the constructor throws an exception:
         using (var throws = new ConstructorThrows(35)) {
            
         }
      }
