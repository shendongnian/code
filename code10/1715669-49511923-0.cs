            string connectionString = "[YOUR_CONNECTION_STRING]";
            ICCqueueLabelDropDownList.Items.Clear();
            string queryString = "(SELECT  [name] FROM [asterisk].[dbo].[sip_friends] where name = '" + phoneNumberDropDownList.SelectedItem + "');";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand selectCmd = new SqlCommand(queryString, conn);
            SqlDataReader myReader = null;
            bool value = false;
            try
            {
                conn.Open();
                myReader = selectCmd.ExecuteReader();
                if (myReader.Read())
                {
                    if (myReader["name"].ToString() != "")  
                    {
                        value = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            myReader.Close();
            conn.Close();
            return (value);
        }
