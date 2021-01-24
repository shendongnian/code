    using System.Data;
    using MySql.Data.MySqlClient;
    using System.Web.Script.Serialization;
    using System.Net;
    using Newtonsoft.Json;
    using System.Configuration;
    using System.Net.NetworkInformation;
        private void btnExportJson_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\SAKTHYBAALAN-PC\Desktop\app_sample.json";
            if(File.Exists(filePath))
            {
                MessageBox.Show("Sorry! The file is already exists, Please restart the operation","File Exists");
                File.Delete(filePath);
            }
            else
            {
                MySQL mysql = new MySQL();
                var source_result = false;
                source_result = mysql.check_connection(myConString);
                if (source_result == false)
                {
                    MessageBox.Show("Sorry! Unable to connect with XAMP / WAMP or MySQL.\n Please make sure that MySQL is running.", "Local Database Connection Failure"); // label1.Text = label1.Text + " ::Error In Source Connection";
                }
                else
                {
                    // MessageBox.Show("Connected");
                    int count = 0;
                    using (var connection = new MySqlConnection(myConString))
                    {
                        connection.Open();
                        // get the names of all tables in the chosen database
                        var tableNames = new List<string>();
                        using (var command = new MySqlCommand(@"SELECT table_name FROM information_schema.tables where table_schema = @database", connection))
                        {
                            command.Parameters.AddWithValue("@database", "app_erp_suneka");
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    tableNames.Add(reader.GetString(0));
                            }
                        }
                        // open a JSON file for output; use the streaming JsonTextWriter interface to avoid high memory usage
                        using (var streamWriter = new StreamWriter(filePath))  //C:\Temp\app_erp_suneka.json"))
                        // For seperate lines may be huge capacity
                        using (var jsonWriter = new JsonTextWriter(streamWriter) { Formatting = Newtonsoft.Json.Formatting.Indented, Indentation = 2, IndentChar = ' ' })
                        //using (var jsonWriter = new JsonTextWriter(streamWriter) )
                        {
                            // one array to hold all tables
                            jsonWriter.WriteStartArray();
                            foreach (var tableName in tableNames)
                            {
                                //MessageBox.Show(tableName);
                                count += 1;
                                // an object for each table
                                jsonWriter.WriteStartObject();
                                jsonWriter.WritePropertyName("tableName");
                                jsonWriter.WriteValue(tableName);
                                jsonWriter.WritePropertyName("rows");
                                // an array for all the rows in the table
                                jsonWriter.WriteStartArray();
                                // select all the data from each table
                                using (var command = new MySqlCommand(@"SELECT * FROM " + tableName + " WHERE (last_updated >= '" + today + "') OR (added_on >= '" + today + "')", connection))
                                // using (var command = new MySqlCommand(@"SELECT * FROM " + tableName + " WHERE (last_updated <= '" + thisDay + "')", connection))
                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        // write each row as a JSON object
                                        jsonWriter.WriteStartObject();
                                        for (int i = 0; i < reader.FieldCount; i++)
                                        {
                                            jsonWriter.WritePropertyName(reader.GetName(i));
                                            jsonWriter.WriteValue(reader.GetValue(i));
                                        }
                                        jsonWriter.WriteEndObject();
                                    }
                                }
                                jsonWriter.WriteEndArray();
                                jsonWriter.WriteEndObject();
                            }
                            jsonWriter.WriteEndArray();
                            MessageBox.Show("Totally " + count + " tables circulated", "Success");
                            btnUploadToServer.Enabled = true;
                            // Application.Exit();
                            //btnUploadToServer_Click(sender, e);
                        }
                    }
                }
            }
        }
