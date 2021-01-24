    private void findImagesInDirectory(string path)
    {
        string[] files = Directory.GetFiles(path);
        foreach(string s in files)
        {
            if (s.EndsWith(".jpg") || s.EndsWith(".png")) //add more format files here
             {
                Imagefiles.Add(s);
             }
         }
         try
         {
             pictureBox1.ImageLocation = Imagefiles.First();
         }
         catch { MessageBox.Show("No files found!"); }
                
    }
