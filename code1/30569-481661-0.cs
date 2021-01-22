          if (!ValidatePage()) return;
        	FormsAuthentication.SignOut();
                MembershipCreateStatus status;
                Data.User user = UserManager.CreateUser(txtEmail.Text.Trim(), txtPassword.Text.Trim(), out status);
                switch (status) { 
			case MembershipCreateStatus.Success:
                                UserManager.Save(user);
				Response.Redirect("~/login.aspx");
                                break;
                        default:
                                lblMessage.Text = status.ToString();
                                break;
                }       
        }
