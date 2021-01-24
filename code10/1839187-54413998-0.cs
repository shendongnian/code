       connectionn.Open();
       OleDbCommand command = new OleDbCommand();
       command.Connection = connectionn;
       string query = "update LOGIN set pass=@Password WHERE UserId=@UserId";
       command.CommandText = query;
       // Some form of hashing should definitely be done here! Should NOT be plain text
       command.AddWithValue("@Password", NPassword.Text); 
       // Not provided in your question but should use this parameter to update the proper column and not try to match on a password field
       command.AddWithValue("@UserId", userId); 
       command.ExecuteNonQuery();
       MessageBox.Show("Password Changed");
       connectionn.Close();
    }
    catch (Exception ex)
    {
       MessageBox.Show("Error, fill the fields required" + ex);
       connectionn.Close();
    }
