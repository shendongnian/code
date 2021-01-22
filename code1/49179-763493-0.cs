    FilesDataContext db = new FilesDataContext();
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < Request.Files.Count; i++)
        {
            StoreFile(Request.Files[i]);
        }
        db.SubmitChanges();
    }
    private void StoreFile(HttpPostedFile file)
    {
        byte[] data = new byte[file.ContentLength];
        file.InputStream.Read(data, 0, file.ContentLength);
        File f = new File();
        f.Data = data;
        f.Filename = file.FileName;
        db.Files.InsertOnSubmit(f);
    }
