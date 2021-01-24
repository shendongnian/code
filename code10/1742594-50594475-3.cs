    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace ConsoleApp_C_Sharp
    {
        class Program
        {
            static void Main(string[] args)
            {
                ProcessData();
            }
    
            /// <summary>
            /// Query the database.
            /// </summary>
            /// <returns></returns>
            static DataSet QueryDatabase() 
            {
                // Credentials to your database.
                SqlConnection connection = new SqlConnection(@"Data Source=SERVER-NAME;Initial Catalog=DatabaseName;User ID=user;Password=yourpassword");
                
                // Name of the stored procedure to be excecuted and connection to database.
                SqlCommand command = new SqlCommand("QueryAllDatabases", connection);
                
                // DataSet to store the query results.
                DataSet result = new DataSet();
                
                // To excecute and fill the dataset.
                SqlDataAdapter da = new SqlDataAdapter(command);
    
                // Set the sqlcommand to "Stored Procedure".
                command.CommandType = CommandType.StoredProcedure;
    
                // Pass some parameters to your database's Stored Procedure if you need to.
                // We're sending some quick dummy params here.
                command.Parameters.AddWithValue("active", "1");
                command.Parameters.AddWithValue("birthdate", "2018-05-29");
    
                // Open connection to database.
                connection.Open();
                // Execute the stored procedure and fill the dataset.
                da.Fill(result);
                // Close the connection.
                connection.Close();
    
                // Object disposal.
                da.Dispose();
                command.Dispose();
                connection.Dispose();
    
                // Return the query results.
                return result;
            }
    
            /// <summary>
            /// Construct the message body and send it by smpt mail.
            /// </summary>
            static void ProcessData()
            {
                // Store the query results.
                DataSet ds = new DataSet();
                // StringBuilder to construct your HTML table.
                StringBuilder table = new StringBuilder();
    
                // Get data from database;
                ds = QueryDatabase();
    
                // If records available:
                if( ds.Tables.Count > 0 )
                {
                    // Start table's header construct.
                    table.Append("<table><thead><tr>");
    
                    // Iterate through each column to insert the column name in the custom table.
                    foreach (DataColumn col in ds.Tables[0].Columns)
                    {
                        table.Append("<td>" + col.ColumnName + "</td>");                    
                    }
    
                    // End header construct.
                    table.Append("</tr></thead>");
                }
    
                // Now, iterate the database records.
                foreach (DataRow row in ds.Tables[0].Rows )
                {
                    // Insert one TR per row.
                    table.Append("<tr>");
                    foreach(DataColumn dc in ds.Tables[0].Columns)
                    {
                        // Insert each data column into a TD cell.
                        table.Append("<td>");
                        table.Append(row[dc.ColumnName]);
                        table.Append("</td>");
                    }
                    // Close the table row and goto next record if available or exit loop.
                    table.Append("</tr>");
                }
    
                // All records inserted. Close the table.
                table.Append("</table>");
    
                // Dsiplay the table in console.
                Console.WriteLine(table.ToString());
                Console.ReadKey();
    
                /*
                 * 
                 * From here you could send "table.ToString()" as the "Body" parameter to your SMTP mail library.
                 * 
                 * */
            }
        }
    }
