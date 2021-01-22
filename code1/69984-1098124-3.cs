    //Database connection code...
    cmd.CommandText = "SELECT FileData FROM Files WHERE ID = @ID";
    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = 1234;
    SqlDataReader sqlRead = cmd.ExecuteReader();
    string fileName = "file.txt";
    string fileDir = "C:\\Test\\";
    string fileUrl = "/";
    if (sqlRead.HasRows)
    {
        while(sqlRead.Read())
        {
            byte[] fileData = (byte[]) sqlRead[0].Value;
            BinaryWriter fileCreate = 
                new BinaryWriter(File.Open(fileDir + fileName, FileMode.Create));
            fileCreate.Write(fileDate);
            fileCreate.Close();
            HttpResponse.Redirect(fileUrl + fileName);
        }
    }
    sqlRead.Close();
