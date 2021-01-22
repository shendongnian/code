    partial class frmCaseWpf {
        public frmCaseWpf {
             this.OnLoaded += frmCaseWpf_OnLoaded;
        }
        private void frmCaseWpf_OnLoaded(object sender, RoutedEventArgs e)
        {
             if (this.openWindow != null)
             {
                  // Show message box, active this.openWindow, close this
             }
             this.openWindow = this;
        }
    }
