    public partial class CustomTextBox : TextBox {
        public CustomTextBox() 
            : base() {
            this.Enter += new EventHandler(Enter);
        }
        protected virtual Enter(object sender, EventArgs e) {
            this.SelectAll();
        }
    }
