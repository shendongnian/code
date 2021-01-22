try
        {
            // Setup our command.
            SqlCommand theCommand = new SqlCommand("SELECT * FROM Inputs", connectSQL);
            // Write the stored value in the text boxes.
            connectSQL.Open();
            SqlDataReader theReader;
            theReader = theCommand.ExecuteReader();
            theReader.Read();
            TextBox6.Text = (theReader["ApplicationName"].ToString());
            
            theReader.Close();
            connectSQL.Close();
        }
        catch (Exception ee)
        {
            MessageBox("Oopsie: " + ee);
        }       
