            if (User.IsInRole("Administrators"))
			{
				accessDeniedMessage.Visible = true;
                adminPage.Visible = false;
			}
			else
			{
                adminPage.Visible = true;
				// show admin page
			}
