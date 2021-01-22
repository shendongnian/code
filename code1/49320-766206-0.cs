    public delegate void MyDelegate();
    private void Delegate_Handler() { }
    void Init() {
      MyDelegate x = new MyDelegate(this.Delegate_Handler);
    }
