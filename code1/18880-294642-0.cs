    try
            {
                // code here which throws exception
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Access Denied"))
                {
                    MessageBox.Show("Sorry, Access Denied", "This is a polite error message");
                }
            }
