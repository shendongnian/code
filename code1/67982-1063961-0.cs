    public void OnUserSelected(object sender, EventArgs e)
    {
          var lstBox = sender as ListBox;
          if (lstBox != null)
          {
              if (lstBox.SelectedItem is User)
              {
                   var user = lstBox.SelectedItem as User;
                   OpenChatWindow(user.ID, user.Name);
              }
          }
    }
