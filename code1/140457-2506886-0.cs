      public class Class1 : IMyInterface {
        public event EventHandler<MyEventArgs> MyEvent;
        public Class1() {
          this.Slider.ValueChanged += OnSliderValueChanged;
        }
        private void OnSliderValueChanged(object sender, EventArgs e) {
          var handler = MyEvent;
          if (handler != null) {
            handler(this, new MyEventArgs());
          }
        }
      }
