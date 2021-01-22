    protected void UploadMultipleFiles(object sender, EventArgs e)
    {
        Common.UploadDocuments(Common.getContext(new Uri(Request.QueryString["SPHostUrl"]),
        Request.LogonUserIdentity), FileUpload1.PostedFiles, new CustomerRequirement(), 5);
    }
    
    public static List<string> UploadDocuments<T>(ClientContext ctx,IList<HttpPostedFile> selectedFiles, T reqObj, int itemID)
    {
        List<Attachment> existingFiles = null;
        List<string> processedFiles = null;
        List<string> unProcessedFiles = null;
        ListItem item = null;
        FileStream sr = null;
        AttachmentCollection attachments = null;
        byte[] contents = null;
        try
        {
            existingFiles = new List<Attachment>();
            processedFiles = new List<string>();
            unProcessedFiles = new List<string>();
            //Get the existing item
            item = ctx.Web.Lists.GetByTitle(typeof(T).Name).GetItemById(itemID);
            //get the Existing attached attachments
            attachments = item.AttachmentFiles;
            ctx.Load(attachments);
            ctx.ExecuteQuery();
            //adding into the new List
            foreach (Attachment att in attachments)
                existingFiles.Add(att);
            //For each Files which user has selected
            foreach (HttpPostedFile postedFile in selectedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                //If selected file not exist in existing item attachment
                if (!existingFiles.Any(x => x.FileName == fileName))
                {
                    //Added to Process List
                    processedFiles.Add(postedFile.FileName);
                }
                else
                    unProcessedFiles.Add(fileName);
            }
            //Foreach process item add it as an attachment
            foreach (string path in processedFiles)
            {
                sr = new FileStream(path, FileMode.Open);
                contents = new byte[sr.Length];
                sr.Read(contents, 0, (int)sr.Length);
                var attInfo = new AttachmentCreationInformation();
                attInfo.FileName = Path.GetFileName(path);
                attInfo.ContentStream = sr;
                item.AttachmentFiles.Add(attInfo);
                item.Update();
            }
            ctx.ExecuteQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            existingFiles = null;
            processedFiles = null;
            item = null;
            sr = null;
            attachments = null;
            contents = null;
            ctx = null;
    
        }
        return unProcessedFiles;
    }
