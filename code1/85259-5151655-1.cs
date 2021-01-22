    Public int InsertUpdateImage(
            ref System.Data.SqlClient.SqlConnection _SqlConnection,
            string _SQL,
            System.Drawing.Image _Image,
            string _ImageFieldName,
            System.Drawing.Imaging.ImageFormat _ImageFormat)
    {
        int _SqlRetVal = 0;
    
        try
        {
            // lets add this record to database
            System.Data.SqlClient.SqlCommand _SqlCommand
                = new System.Data.SqlClient.SqlCommand(_SQL, _SqlConnection);
    
            // Convert image to memory stream
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
            _Image.Save(_MemoryStream, _ImageFormat);
    
            // Add image as SQL parameter
            System.Data.SqlClient.SqlParameter _SqlParameter 
                = new System.Data.SqlClient.SqlParameter("@" + _ImageFieldName, SqlDbType.Image);
           
            _SqlParameter.Value = _MemoryStream.ToArray();
            _SqlCommand.Parameters.Add(_SqlParameter);
    
            // Executes a Transact-SQL statement against the connection 
            // and returns the number of rows affected.
            _SqlRetVal = _SqlCommand.ExecuteNonQuery();
    
            // Dispose command
            _SqlCommand.Dispose();
            _SqlCommand = null;
        }
        catch (Exception _Exception)
        {
            // Error occurred while trying to execute reader
            // send error message to console (change below line to customize error handling)
            Console.WriteLine(_Exception.Message);
    
            return 0;
        }
    
        return _SqlRetVal;
    }
