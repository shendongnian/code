    public class MainMdiForm : Form
    {
        ...
    
        UserForm userForm;
    
        ...
    
        private void ShowUserForm()
        {
            if(userForm == null || userForm.IsDisposed)
            {
                userForm = new UserForm();
                userForm.MdiParent = this;
            }
    
            userForm.Show();
            userForm.BringToFront();
        }
    }
