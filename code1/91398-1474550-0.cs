    public class GetUserForm : Form
    {
        public object SelectedComboValue
        {
            // I return type object here, since i do not know what you want to return
            get 
            {
               return MyComboBox.SelectedValue; 
            }
        }
    }
