    class MainWindow
    {
      private string _email;
      private string _password;
    
      private void btnLogin_Click(...)
      {
        // running on UI thread here - can touch text boxes
        _email = txtEmail.Text;
        _password = txtPwd.Text;
        // ... set up worker ...
        worker.RunWorkerAsync();
      }
    
      private void login()
      {
        binding = new Service();
        // running on background thread here
        // but safe to access _email and _password they're just data, not UI controls
        lr = binding.login(_email, _password);
      }
    }
