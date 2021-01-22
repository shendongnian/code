    public partial class SecondaryForm : Form {
        public MainForm OwnerForm {
            get {
                return (MainForm)this.Owner;
            }
        }
        public void someMethod() {
            OwnerForm.ContentDescription = "file contents";
        }
    }
    
