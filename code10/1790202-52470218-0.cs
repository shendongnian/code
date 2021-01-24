        public class DatabaseFile
        {
            /// <summary>
            /// The file name, the database column to which it corresponds is a nvarchar(256)
            /// </summary>
            public string Name = string.Empty;
            /// <summary>
            /// The Mime type of the file, the database column to which it corresponds is a nvarchar(64)
            /// </summary>
            public string Mime = string.Empty;
            /// <summary>
            /// The file data as a base64 string, the database column to which it corresponds is a ntext
            /// </summary>
            public string Data = string.Empty;
            /// <summary>
            /// The file data as a byte array
            /// </summary>
            public byte[] BinaryData
            {
                get { return Convert.FromBase64String(Data); }
                set { Data = Convert.ToBase64String(value); }
            }
            /// <summary>
            /// Constructor to create a DatabaseFile from a HttpPostedFile
            /// </summary>
            /// <param name="file"></param>
            public DatabaseFile(HttpPostedFile file)
            {
                Name = file.FileName;
                Mime = file.ContentType;
                byte[] fileBytes = new byte[file.ContentLength];
                file.InputStream.Read(fileBytes, 0, file.ContentLength);
                BinaryData = fileBytes;
            }
            /// <summary>
            /// Save the file information and data to a database table called [FileTable].
            /// </summary>
            /// <param name="sqlConnection"></param>
            public void SaveToDatabase(SqlConnection sqlConnection)
            {
                
                // Parameterized Insert command
                SqlCommand sqlCommand = new SqlCommand("insert [FileTable] ([Name], [Mime], [Data]) values (@Name, @Mime, @Data)", sqlConnection);
                // Create the necessary parameters
                sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 256);
                sqlCommand.Parameters.Add("@Mime", SqlDbType.NVarChar, 64);
                sqlCommand.Parameters.Add("@Data", SqlDbType.NText);
                // Assign the parameters
                sqlCommand.Parameters["@Name"].Value = Name;
                sqlCommand.Parameters["@Mime"].Value = Mime;
                sqlCommand.Parameters["@Data"].Value = Data;
                // Execute the command
                try
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
