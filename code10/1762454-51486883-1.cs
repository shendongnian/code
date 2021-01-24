		using (SqlCommand cmd = new SqlCommand(@"select * from [Schedule] where Working = datename(weekday,GetDate()) and Commencing != Finishing; 
          select * from [Vacation] where VacStart = GetDate();", con))
		{
			con.Open();
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				DateTime now = DateTime.Today;
				// from Schedule Table
				while (reader.Read())
				{
					string working = reader.GetString(1);
					DateTime commencing = reader.GetDateTime(2);
					DateTime finishing = reader.GetDateTime(3);
					// if condition is not met
					if (working != null && now >= commencing && finishing <= now)
					{
						// if condition met
						lblMsg2.Text = "<p class='open'>Yes, we are currently open and would love to hear from you!</p>";
					}
					else
					{
						// if condition is not met
						lblMsg2.Text = "<p class='closed'>Sorry, we are currently closed. You can reach us during normal business hours. We would love to have the opportunity to speak with you!</p>";
					}
				}
				// from Vacation Table
				if (reader.NextResult())
				{
					while (reader.Read())
					{
						string reason = reader.GetNullableString(1);
						if (reason == null)
						{
							// if condition is met
							lblMsg2.Text = "<p class='closed'>Sorry, we are closed for for a personal holiday.<br />If you are a current client and this is an emergency, we will of course make every effort to accommodate you.</p>";
						}
					}
				}
			}
