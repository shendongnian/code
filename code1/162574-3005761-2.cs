    public partial class YourMainForm : Form
    {
       private MainMenuForm _mainMenu = new MainMenuForm();
    
       protected void ShowForm()
       {
          _mainMenu.Show();
       }
    
       protected void HideForm()
       {
          _mainMenu.Hide();
       }
    }
