     protected void Button1_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = FileUpload1.PostedFile;
            using (ChannelFactory<IFileUpload> uploadPdf = new ChannelFactory<IFileUpload>("upload"))
            {   
                IFileUpload fileUpload = uploadPdf.CreateChannel();
                byte[] bys = new byte[file.InputStream.Length];
                file.InputStream.Read(bys, 0, bys.Length);
                fileUpload.Upload(bys);
            }
        }
