    public partial class FormOptions : Form
    {
      public DialogResult ShowDialog(out string result)
      {
        DialogResult dialogResult = base.ShowDialog();
        result = m_Result;
        return dialogResult;
      }
    }
