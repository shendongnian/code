    public class CustDialog
    {
       private OpenFileDialog _dialog;
    
       public CustDialog()
       {
           //instantiate custom OpenFileDialog here
       }
       
       public DialogResult ShowDialog()
       {
           return _dialog.ShowDialog();
       }
    }
