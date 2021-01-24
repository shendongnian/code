    private CancellationTokenSource uploadCancellationTokenSource = new CancellationTokenSource();
    public uploadFileData uploadToMega(string megaFolderName, string megaFolderID, string filePathOnComputer, string newFileNameOnMega)
    {
        //Implemnt Struct
        uploadFileData myMegaFileData = new uploadFileData();
        //Start Mega Cient
        var myMegaClient = new MegaApiClient();
        //Login To Mega
        myMegaClient.Login(Userrrr, Passss);
        //Get All (File & Folders) in Mega Account
        IEnumerable<INode> nodes = myMegaClient.GetNodes();
        //Creat List Of All Folders In Mega Account
        List<INode> megaFolders = nodes.Where(n => n.Type == NodeType.Directory).ToList();
        //Choose Exist Folder In Mega Account By Name & Id
        INode myFolderOnMega = megaFolders.Where(folder => folder.Name == megaFolderName && folder.Id == megaFolderID).FirstOrDefault();
        //Upload The File
        //Normal Upload
        //INode myFile = myMegaClient.UploadFile(filePathOnComputer, myFolderOnMega);
        //NEWLY ADDED
        var progress = new Progress<double>();
        progress.ProgressChanged += (s, progressValue) =>
        {
            //Update the UI (or whatever) with the progressValue 
            progressBar1.Value = Convert.ToInt32(progressValue);
        };
        //NEWLY ADDED
        if (uploadCancellationTokenSource.IsCancellationRequested)
        {
            uploadCancellationTokenSource.Dispose();
            uploadCancellationTokenSource = new CancellationTokenSource();
        }
        // Upload With progress bar
        INode myFile = myMegaClient.UploadFileAsync(filePathOnComputer, myFolderOnMega, progress, uploadCancellationTokenSource.Token);
        //Rename The File In Mega Server
        if (string.IsNullOrEmpty(newFileNameOnMega))
        {
        }
        else
        {
            myMegaClient.Rename(myFile, newFileNameOnMega);
        }
        //Get Download Link
        Uri downloadLink = myMegaClient.GetDownloadLink(myFile);
        myMegaFileData.megaFileId = myFile.Id;
        Clipboard.SetText(myMegaFileData.megaFileId);
        myMegaFileData.megaFileType = myFile.Type.ToString();
        myMegaFileData.megaFileName = myFile.Name;
        myMegaFileData.megaFileOwner = myFile.Owner;
        myMegaFileData.megaFileParentId = myFile.ParentId;
        myMegaFileData.megaFileCreationDate = myFile.CreationDate.ToString();
        myMegaFileData.megaFileModificationDate = myFile.ModificationDate.ToString();
        myMegaFileData.megaFileSize = myFile.Size.ToString();
        myMegaFileData.megaFileDownloadLink = downloadLink.ToString();
        myMegaClient.Logout();
        return myMegaFileData;
    }
    private void CancelUploadButtonClick(object sender, EventArgs e)
    {
        if (!uploadCancellationTokenSource.IsCancellationRequested)
            uploadCancellationTokenSource.Cancel();
    }
