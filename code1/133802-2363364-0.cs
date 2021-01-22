      public partial class Window1 : Window {
        DispatcherTimer mIdle;
        private const long cIdleSeconds = 3;
        public Window1() {
          InitializeComponent();
          InputManager.Current.PreProcessInput += Idle_PreProcessInput;
          mIdle = new DispatcherTimer();
          mIdle.Interval = new TimeSpan(cIdleSeconds * 1000 * 10000);
          mIdle.IsEnabled = true;
          mIdle.Tick += Idle_Tick;
        }
    
        void Idle_Tick(object sender, EventArgs e) {
          this.Close();
        }
    
        void Idle_PreProcessInput(object sender, PreProcessInputEventArgs e) {
          mIdle.IsEnabled = false;
          mIdle.IsEnabled = true;
        }
      }
