    sealed partial class MainWindow : IDisposable {
        readonly IDisposable disposable;
        public MainWindow() {
            disposable = ...
		}
		public void Dispose() {
			disposable.Dispose();
		}
		
		protected override void OnClosed(EventArgs e) {
			Dispose();
			base.OnClosed(e);
		}
    }
