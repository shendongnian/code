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
           MessageBox.Show("I passed a value to the main class!");
        }
    }
