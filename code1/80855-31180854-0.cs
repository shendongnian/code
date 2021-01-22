    private void Deletebt_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(@"" + delete.Text);
            foreach (FileInfo file in myDirInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }
 
