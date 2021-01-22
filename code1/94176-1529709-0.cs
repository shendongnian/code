	if (graphicMultiFile.Files.Length > 0)          
            {       
                string connectionString = ConfigurationManager.ConnectionStrings["DataConnect"].ConnectionString;                
                foreach (UploadedFile file in graphicMultiFile.Files)             
                {                 
                    string sku = file.FileName.Substring(0, file.FileName.Length - 4);                 
                    string directoryPath = Server.MapPath("~/images/graphicsLib/" + file.FileName);                 
                    file.MoveTo(directoryPath, MoveToOptions.Overwrite);                 
                                   
                    SqlConnection conn = new SqlConnection(connectionString);       
                    SqlCommand comm = new SqlCommand("exec addOrUpdateImageRecord @sku, @imagePath");                
                    comm.Parameters.Add("@sku", System.Data.SqlDbType.VarChar, 50);                
                    comm.Parameters["@sku"].Value = sku;               
                    comm.Parameters.Add("@imagePath", System.Data.SqlDbType.VarChar, 300);               
                    comm.Parameters["@imagePath"].Value = "images/graphicsLib/" + file.FileName;               
                    conn.Open();             
                    comm.ExecuteNonQuery();             
                    conn.Close();           
                }         
            }      
