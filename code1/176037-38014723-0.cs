    public static  bool ExistsFile()
    {
        BasicAWSCredentials basicCredentials = new BasicAWSCredentials("my access key", "my secretkey");
                    AmazonS3Config configurationClient = new AmazonS3Config();
                    configurationClient.RegionEndpoint = RegionEndpoint.EUCentral1;
                    
                    try
                    {
                        using (AmazonS3Client clientConnection = new AmazonS3Client(basicCredentials, configurationClient))
                        {
        
                            S3FileInfo file = new S3FileInfo(clientConnection, "mybucket", "FolderNameUniTest680/FileNameUnitTest680");
                            return file.Exists;//if the file exists return true, in other case false
                        }
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
        }
