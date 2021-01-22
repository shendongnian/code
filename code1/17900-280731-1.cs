    public partial class FormOptions : Form
    {
      public DialogResult ShowDialog(string out result)
      {
        DialogResult dialogResult = base.ShowDialog();
        result = m_Result;
        return dialogResult;
      }
    }
