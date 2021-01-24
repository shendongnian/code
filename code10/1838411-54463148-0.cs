       public void getAttachedFiles(int id)
            {
                imageList.Items.Clear();
                docList.Items.Clear();
                string fileName;
                string fileExtension;
                byte[] fileData;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Utilities.ConnectionString;
                conn.Open();
                string query = "select cf.Data,cf.Name,cf.ContentType from[dbo].[Channels_Files] cf where cf.ChannelId =" + id;
                DataTable listFiles = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(query, conn);
                adp.Fill(listFiles);
                foreach (DataRow dataRow in listFiles.Rows)
                {
                 
                    fileData = (byte[])dataRow.ItemArray[0];
                    fileName = dataRow.ItemArray[1].ToString();
                    fileExtension = dataRow.ItemArray[2].ToString();
                    displayFile(fileName,fileExtension, fileData);
                }
            }
