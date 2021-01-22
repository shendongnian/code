    public void MyMethod(params object[] parameters) {
         foreach (var p in parameters) {
             ...
         }
    }
    // method call:
    this.MyMethod("foo", "bar", 123, null, new MyClass());
