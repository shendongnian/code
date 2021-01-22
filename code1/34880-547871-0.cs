     SqlConnection myConn = new SqlConnection("Connectionstring");
            try
            {
                myConn.Open();
                //make na DB Request                
            }
            catch (Exception DBException)
            {
                //do somehting with exception
            }
            finally
            {
               myConn.Close();
               myConn.Dispose();
            }
