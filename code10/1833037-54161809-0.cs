    private void btnUpdatePassword_Click(object sender, EventArgs e)
    {
        string oldusername = txtBoxOldUsername.Text;
        string newusername = txtBoxNewUsername.Text;
        string oldpassword = txtBoxOldPassword.Text;
        string newpassword = txtBoxNewPassword.Text;
        string text = File.ReadAllText("users.txt");
        text = text.Replace(oldpassword + oldusername, newpassword + newusername).Replace(oldusername, newusername);
        File.WriteAllText("users.txt", text);
    }
