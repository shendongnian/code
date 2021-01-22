        TextBox myCaption = (TextBox)ProjectPhotosList.EditItem.FindControl("ProjectPhotoCaptionTextBox");
        int mykey = int.Parse(ProjectPhotosList.DataKeys[e.ItemIndex].Value.ToString());
        if (myFile.HasFile)
        {
            //Get the posted file
            Stream fileDataStream = myFile.PostedFile.InputStream;
            //Get length of file
            int fileLength = myFile.PostedFile.ContentLength;
            //Create a byte array with file length
            byte[] fileData = new byte[fileLength];
            //Read the stream into the byte array
            fileDataStream.Read(fileData, 0, fileLength);
            //get the file type
            string fileType = myFile.PostedFile.ContentType;
            //Open Connection
            PHJamesDataContext db = new PHJamesDataContext();
            //Find the Right Row
            PHJProjectPhoto Newphoto = (from p in db.PHJProjectPhotos
                                        where p.ProjectPhotoId == mykey
                                        select p).Single<PHJProjectPhoto>();
            Newphoto.ProjectPhoto = fileData;
            db.SubmitChanges();
        }
