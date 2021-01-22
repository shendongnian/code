    public EventHandler<MyEventArgs> MyEvent;
    protected virtual OnMyEvent(MyEventArgs args) {
      var copy = MyEvent;
      if (copy != null) {
        copy(this, args);
      }
    }
