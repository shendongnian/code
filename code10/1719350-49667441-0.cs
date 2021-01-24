    public class MyClass
    {
        private _dialogResult DialogResult;
    
        public DialogResult MyDialogResult
        {
           get { return _dialogResult; }
           set 
           {
              _diaologResult = value;
              ShowYourMessage();
           }
        }
        private void ShowYourMessage()
        {
           using (Form frmMessage = new Form())
           {
              // set stuff on your form here, like _dialogResult and whatever you need...
              frmMessage.ShowDialog();
           }
        }
    }
