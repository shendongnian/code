			IDriveFile file = DriveClass.DriveApi.GetFile(GoogleInfo.GetInstance().SignInApi, driveID);
            file.GetMetadata(mGoogleApiClient).SetResultCallback(metadataRetrievedCallback());
            Task.Run(() =>
            {
                var driveContentsResult = file.Open(mGoogleApiClient,
                    DriveFile.ModeReadOnly, null).Await();
                IDriveContents driveContents = driveContentsResult.JavaCast<IDriveApiDriveContentsResult>().DriveContents;
                Stream inputstream = driveContents.InputStream;
                byte[] buffer = new byte[16 * 1024];
                int read;
                MemoryStream output = new MemoryStream();
               
                while ((read = inputstream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, read);
                }
 
