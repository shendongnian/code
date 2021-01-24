    public partial class FocusTextBox : TextBox {
        public FocusTextBox() {}
    
        protected override void OnGotFocus(EventArgs e) {
            // Your code to open the keyboard here
            
            base.OnGotFocus(e);
        }
    }
