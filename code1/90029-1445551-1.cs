        protected void btnUpload_Click(object sender, EventArgs e)
    {
        using (StreamReader stRead = new StreamReader(FileUpload1.PostedFile.InputStream))
        {
            while (!stRead.EndOfStream)
            {
                ListBox1.Items.Add(stRead.ReadLine());
            }
        }
    }
