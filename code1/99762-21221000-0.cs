    public class DataForm : Form {
        protected virtual void displayFields() {}
    }
    public partial class Form1 : DataForm {
        protected override void displayFields() { /* Do the stuff needed for Form1. */ }
        ...
    }
    public partial class Form2 : DataForm {
        protected override void displayFields() { /* Do the stuff needed for Form2. */ }
        ...
    }
    /* Do this for all classes that inherit from DataForm. */
