    class Class1 : IMyInterface
    {
        
        public event MyEventEventHandler IMyInterface.MyEvent;
        public delegate void MyEventEventHandler(object sender, MyEventArgs e);
        
        public Class1()
        {
            this.Slider.ValueChanged += OnSliderValueChanged;
        }
        
        private void OnSliderValueChanged(System.Object sender, System.EventArgs e)
        {
            if (MyEvent != null) {
                MyEvent(this, new MyEventArgs());
            }
        }
        
    }
