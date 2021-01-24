	public partial class MainWindow : Window {
		private Timer t;
		public MainWindow() {
			InitializeComponent();
			t = new Timer(onTimer, null, 5000, Timeout.Infinite);
			MouseDown += (s,e) => { SomeContent.some = "iii"; };
		}
		private void onTimer(object state) {
			Dispatcher.Invoke(() => {
				SomeContent.some = "aaaa";
				nested.some = "xxx";
			});
		}
	}
