    private async void BtnLoginUser_Click(object sender, System.EventArgs e)
    {
      string EmailU = txtEmailU.Text.ToString();
      string PasswordU = txtPwU.Text.ToString();
      var user = new ParseUser();
      try
      {
        // ...
        else 
        {
            // ...
            mDialog.Show();                  
            // need = to assign to user
            // also remove var since already declared above (this fixes two errors)
            // OR remove the above declaration!  
            user = await ParseUser.LogInAsync(EmailU, PasswordU);
            // could be == true, but should just be user["emailVerified"]
            if (user["emailVerified"])
            {
                StartActivity(typeof(MainActivity));
            }
            else
            {
                Toast.MakeText(this, "Please Verify", ToastLength.Long).Show();
                return;
            }
        }
    }
    catch (Exception ep)
    {
        Toast.MakeText(this, "Some Error Occured " + ep.Message, ToastLength.Long).Show();
    }
