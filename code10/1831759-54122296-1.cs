        private void panel1_DragEnter(object sender, DragEventArgs e)
           {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
           }
        private void panel1_DragDrop(object sender, DragEventArgs e)
          {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (Path.GetExtension(files[0]).ToLower() == ".pdf")//jpg,bmp,docx,....
            {
                //Code
            }
          }
