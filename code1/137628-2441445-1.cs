    // generate new Guid
    Guid fileguid = Guid.NewGuid();
    
    // set limit for images, 1920x1200 pixels
    int imageWidth = 1920;
    int imageHeight = 1200;
    int maxFileSize = 8388608;
    // web.config - httpRuntime - maxRequestLength="8192"
    // 8,388,608 Bytes 
    // 8,192 KB ( / 1024 ) 
    // 8.00 MB ( / 1024 / 1024 )
    
    string sConn = ConfigurationManager.ConnectionStrings["AssetsDBCS"].ConnectionString;
    SqlConnection objConn = new SqlConnection(sConn);
    objConn.Open();
    SqlCommand objCmd = new SqlCommand("sp_FileStorage_New", objConn);
    objCmd.CommandType = CommandType.StoredProcedure;
    
    SqlParameter paramFileGuid = objCmd.Parameters.Add("@FileGuid", SqlDbType.UniqueIdentifier);
    SqlParameter paramFileSubject = objCmd.Parameters.Add("@Subject", SqlDbType.VarChar);
    SqlParameter paramFileContentType = objCmd.Parameters.Add("@ContentType", SqlDbType.VarChar);
    SqlParameter paramFileData = objCmd.Parameters.Add("@BinaryData", SqlDbType.VarBinary);
    SqlParameter paramFileSize = objCmd.Parameters.Add("@Filesize", SqlDbType.BigInt);
    SqlParameter paramFileDesc = objCmd.Parameters.Add("@Description", SqlDbType.VarChar);
    SqlParameter paramIsSLAFile = objCmd.Parameters.Add("@IsSLAFile", SqlDbType.Bit);
    SqlParameter paramUserStamp = objCmd.Parameters.Add("@UserStamp", SqlDbType.VarChar);
    
    paramFileGuid.Direction = ParameterDirection.Input;
    paramFileSubject.Direction = ParameterDirection.Input;
    paramFileContentType.Direction = ParameterDirection.Input;
    paramFileData.Direction = ParameterDirection.Input;
    paramFileSize.Direction = ParameterDirection.Input;
    paramFileDesc.Direction = ParameterDirection.Input;
    paramIsSLAFile.Direction = ParameterDirection.Input;
    paramUserStamp.Direction = ParameterDirection.Input;
    
    // read data
    byte[] bData = new byte[fuOne.PostedFile.ContentLength];
    Stream objStream = fuOne.PostedFile.InputStream;
    objStream.Read(bData, 0, fuOne.PostedFile.ContentLength);
    
    paramFileSubject.Value = txtSubject.Text;
    
    objCmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = Path.GetFileName(fuOne.PostedFile.FileName);
    objCmd.Parameters.Add("@Extension", SqlDbType.VarChar).Value = Path.GetExtension(fuOne.PostedFile.FileName);
    
    paramFileGuid.Value = fileguid;
    
    paramFileContentType.Value = fuOne.PostedFile.ContentType;
    paramFileData.Value = bData;
    paramFileSize.Value = fuOne.PostedFile.ContentLength;
    paramFileDesc.Value = fuOne.PostedFile.FileName;
    paramIsSLAFile.Value = cbIsSLAFile.Checked;
    paramUserStamp.Value = ac.getUser();
    
    if (fuOne.PostedFile.ContentLength < maxFileSize)
    {
    
        switch (fuOne.PostedFile.ContentType)
        {
            case "image/pjpeg":
                {
    
                    System.Drawing.Image iImage = System.Drawing.Image.FromStream(new MemoryStream(bData));
    
                    if (iImage.Width > imageWidth || iImage.Height > imageHeight)
                    {
                        lblStatus.Text = "The image width or height cannot be greater than " + imageHeight + " x " + imageWidth + " pixels";
                    }
                    else
                    {
                        objCmd.ExecuteNonQuery();
                        objConn.Close();
    
                        hlDownload.Visible = true;
                        hlDownload.NavigateUrl = "Download.aspx?DownloadFileGuid=" + fileguid.ToString();
                        hlDownload.Text = "Click here to download the uploaded file";
    
                        hlShowFile.Visible = true;
                        hlShowFile.NavigateUrl = "Download.aspx?ShowFileGuid=" + fileguid.ToString();
                        hlShowFile.Text = "Click here to view the uploaded file";
    
                        lblStatus.Text = showUploadFileInfo(Path.GetFileName(fuOne.PostedFile.FileName), fuOne.PostedFile.ContentType, fuOne.PostedFile.ContentLength, iImage.Width, iImage.Height);
                    }
                    break;
                }
        }
    }
