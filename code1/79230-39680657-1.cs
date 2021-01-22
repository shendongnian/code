    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    namespace PBDataAccess
    {
        public class AddContact
        {   
            // for preparing connection to sql server database   
            
            private SqlConnection conn; 
            
            // for preparing sql statement or stored procedure that 
            we want to execute on database server
            private SqlCommand cmd; 
            // used for storing the result in datatable, basically 
            dataset is collection of datatable
            private DataSet ds; 
            // datatable just for storing single table
            private DataTable dt; 
            // data adapter we use it to manage the flow of data
            from sql server to dataset and after fill the data 
            inside dataset using fill() method   
            private SqlDataAdapter da; 
            // created a method, which will return the dataset
            public DataSet GetAllContactType() 
            {
        
        // retrieving the connection string from web.config, which will 
        tell where our database is located and on which database we want
        to perform opearation, in this case we are working on stored procedure 
        so you might have created it somewhere in your database. 
         connection string will include the name of the datasource, your 
         database name, user name and password.
            file using configuration manager
            using (conn = new SqlConnection(ConfigurationManager.ConnectionString["conn"]
            .ConnectionString)) 
                    {
                        // Addcontact is the name of the stored procedure
                        using (cmd = new SqlCommand("Addcontact", conn)) 
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                        // here we are passing the parameters that 
                        Addcontact stored procedure expect.
                        cmd.Parameters.Add("@CommandType",
                        SqlDbType.VarChar, 50).Value = "GetAllContactType"; 
                            // here created the instance of SqlDataAdapter
                            class and passed cmd object in it
                            da = new SqlDataAdapter(cmd); 
                            // created the dataset object
                            ds = new DataSet(); 
                            // fill the dataset and your result will be
                            stored in dataset
                            da.Fill(ds); 
                        }                    
                }   
 
               // here we are returning the dataset object, every time
               you will call this method, you will get dataset object 
               filled inside datatable, once you have it, you could 
               retrieve your result from it and work on
                return ds;
            }
    }
