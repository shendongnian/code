    public partial class MainForm
     {
        Void Validate_NotWorking()
        {
        ErrorProvider errorProvider1 = new ErrorProvider();
        errorProvider1.SetError(textbox1, "textbox is empty");
        errorProvider1.Clear();
        }
     }
