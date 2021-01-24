    void SomeInitMethod() {
       pictureBox1.DoubleClick += (s,a) => OnSomeEvent();
       label1.DoubleClick += (s,a) => OnSomeEvent();
       label2.DoubleClick += (s,a) => OnSomeEvent();
    }
    public event EventHandler SomeEvent;
    protected virtual void OnSomeEvent() {
        SomeEvent?.Invoke(this, EventArge.Empty);
    }
