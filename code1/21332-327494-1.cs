    private readonly object syncLock = new object(); // or static if needed
    ...
    public void Foo() {
       lock(syncLock) {
          ...
       }
    }
