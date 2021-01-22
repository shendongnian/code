      List<Users> userList = dal_Users.GetAllUsers();
    
      foreach (Users u in userList )
      {
         ListItem li = new ListItem();
         li.Text = u.ContactDetails.Telephone;
         li.Value = u.userID.ToString();
         ddl.Items.Add(li);
      }
    
      ddl.DataBind();
