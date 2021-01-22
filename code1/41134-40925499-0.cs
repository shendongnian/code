        SqlConnection conn = new SqlConnection("Data Source=" + txtserver.Text.Trim() + ";Initial Catalog=" + txtdatabase.Text.Trim() + ";User ID=" + txtuserid.Text.Trim() + ";Password=" + txtpwd.Text.Trim() + "");
        try
        {
            conn.Open();
            string script = File.ReadAllText(Server.MapPath("~/Script/DatingDemo.sql"));
            // split script on GO command
            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            foreach (string commandString in commandStrings)
            {
                if (commandString.Trim() != "")
                {
                    new SqlCommand(commandString, conn).ExecuteNonQuery();
                }
            }
            lblmsg.Text = "Database updated successfully.";
        }
        catch (SqlException er)
        {
            lblmsg.Text = er.Message;
            lblmsg.ForeColor = Color.Red;
        }
        finally
        {
            conn.Close();
        }
    }
