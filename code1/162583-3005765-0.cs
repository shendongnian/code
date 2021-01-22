    public class MainWindow : Form
    {
        private Form _mainMenuForm = new MainMenuForm();
    
        public void btnShowMenuForm_Click(...)
        {
            _mainMenuForm.Show();
        }
    
        public void btnHideMenuForm_Click(...)
        {
            _mainMenuForm.Hide();
        }
    
        //etc
    }
