    public class UserControl1 : UserControl 
    {
        // private Button saveButton;
        public event EventHandler SaveButtonClick
        {
            add { saveButton.Click += value; }
            remove { saveButton.Click -= value; }
        }
    }
