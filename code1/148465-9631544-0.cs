    public partial class MainForm
     {
        ErrorProvider errorProvider1 = new ErrorProvider();
        void Validate_Working()
        {
        errorProvider1.SetError(textbox1, "textbox is empty");
        errorProvider1.Clear();
        }
     }
