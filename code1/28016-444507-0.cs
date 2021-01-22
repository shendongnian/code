    [WebMethod]
        public String GetPONumber(string Database)
        {   
            //Create Object ready for Value
            object po = "";
            //Set Connection
            SqlConnection Connection = new SqlConnection(GetConnString(Database));
            //Open Connection
            Connection.Open();
            //Set Query to string
            string Query = @" SQL QUERY GOES HERE!!!! ";
            //Run Query
            SqlCommand Command = new SqlCommand(Query, Connection);
            //Set Value from Query
            try
            {
                po = Command.ExecuteScalar();
            }
            catch
            {
                //Error
            }
            //Clean up sql
            Command.Dispose();
            Command = null;
            //Clean up connection
            Connection.Close();
            Connection.Dispose();
            Connection = null;
            
            //Return Value
            return po.ToString();
        }
