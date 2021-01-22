        try
        {
            connection.Open();
            // other codes
        }
        catch (Exception Ex)
        {
            
            // Create a (useful) error message
            string ErrorMessage = "A error occurred while trying to connect to the server.";
            ErrorMessage += Environment.NewLine;
            ErrorMessage += Environment.NewLine;
            ErrorMessage += Ex.Message;
            // Show error message (this = the parent Form object)
            lblMessage.Text = "Error: " + ErrorMessage;
             
        }
        finally
        {
            // close connection
            if (connection != null)
            {
                connection.Close();
            }
        }
