    public partial class Press : SharedElements
        {
            private WpfButton pendingButton;
        public Press(WpfWindow wpfWindow):base(wpfWindow)
            {
                pendingTab = Controls.getWpfButton(_wpfWindow, "Tab1Button");
            }
        public void clickPendingButton() {
            Mouse.Click(pendingButton);
        }
    }
