    public class UserControl1 : UserControl 
    {
        // private Button SaveButton;
        public event EventHandler SaveButtonClick
        {
            add { SaveButton.Click += value; }
            remove { SaveButton.Click -= value; }
        }
    }
