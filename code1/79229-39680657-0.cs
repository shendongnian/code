    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    namespace PBDataAccess
    {
        public class AddContact
        {   
            private SqlConnection conn; // for preparing connection to sql server database
            private SqlCommand cmd; // for preparing sql command or stored procedure that we want to execute on database server
            private DataSet ds; // used for storing the result in datatable, basically dataset is collection of datatable
            //private DataTable dt; // datatable just for storing single table
            private SqlDataAdapter da; // data adapter we use it to manage the flow of data from sql server to dataset and after fill the data inside dataset using fill() method   
    // created a method, which will return the dataset.
            public DataSet GetAllContactType() // name of the method and it returns dataset
            {
                    using (conn = new SqlConnection(ConfigurationManager.ConnectionString["conn"].ConnectionString)) // retrieving the connection string from web.config file using configuration manager
                    {
                        using (cmd = new SqlCommand("Addcontact", conn)) // Addcontact is the name of the stored procedure
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@CommandType", SqlDbType.VarChar, 50).Value = "GetAllContactType"; // here we are passing the parameters that Addcontact stored procedure expect.
                            da = new SqlDataAdapter(cmd); // here created the instance of SqlDataAdapter class and passed cmd object in it
                            ds = new DataSet(); // created the dataset object
                            da.Fill(ds); // fill the dataset and your result will be stored in dataset
                        }                    
                }    
                return ds; // here we are returning the dataset object, every time you will call this method, you will get dataset, once you have it, you could retrieve your result from it.
            }
    }
