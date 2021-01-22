    protected void Button1_Click(object sender, EventArgs e) 
    { 
        try 
        { 
            string completeFileName = 
               Path.Combine(@"\\192.168.1.3\upload", FileUpload1.FileName); 
            BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream);
            
            FileStream fstm = new FileStream(completeFileName, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fstm);
            
            byte[] buffer = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
            br.Close();
            bw.Write(buffer);
            bw.Flush();
            bw.Close();
        } 
        catch (Exception ex) 
        { 
            Console.WriteLine(ex.Message); 
        } 
    } 
