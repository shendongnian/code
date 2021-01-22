       private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
                try
                {
                    ProgressInfo img = e.UserState as ProgressInfo;
                    LoadImages(img);
                    this.progressBar1.Value = img.Percent;
                    this.label1.Text = "Loading images...";
                }
                catch (Exception ex)
                {
                   throw ex;
                }
        }
        private void LoadImages(ProgressInfo img)
        {
            ImgListView.Images.Add(getThumbnaiImage(ImgListView.ImageSize.Width, img.Image));
            this.lstThumbNailView.Invoke((Action)delegate
            {
                fname = System.IO.Path.GetFileName(files[img.ImageIndex]);
                ListViewItem lvwItem = new ListViewItem(fname, img.ImageIndex);
                lvwItem.Tag = files[img.ImageIndex]; 
                lstThumbNailView.Items.Add(lvwItem); 
            });
        }
