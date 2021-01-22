            if (User.IsInRole("Administrators"))
			{
				accessDeniedMessage.Visible = true;
			}
			else
			{
				// show admin page
			}
