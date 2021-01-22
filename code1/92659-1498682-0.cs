           try{ 
           int progress = 0;
            string pname;
            Image myImage;
            max_length = files.Length - 2;
            for (i = 0; i < files.Length; i++)
            {
              ProgressInfo info = new ProgressInfo();
                pname = System.IO.Path.GetFullPath(files[i]);
                myImage = Image.FromFile(pname);
                info.Image = myImage;
                info.ImageIndex = i;
                backgroundWorker1.ReportProgress(progress, info);
                myImage = null;
            }
        
           }
           catch (TargetInvocationException tiEx)
           {
               throw tiEx.InnerException;
           }
           catch (Exception ex)
           {
               throw ex.InnerException;
           }
        }
      private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                 ProgressInfo img = e.UserState as ProgressInfo;
                //Set image to ListView here.
                ImgListView.Images.Add(getThumbnaiImage(ImgListView.ImageSize.Width, img.Image));
                fname = System.IO.Path.GetFileName(files[img.ImageIndex]);
                ListViewItem lvwItem = new ListViewItem(fname, img.ImageIndex);
                lvwItem.Tag = files[i];
                lstThumbNailView.Items.AddRange(new ListViewItem[] { lvwItem });
                         
            }
            catch (TargetInvocationException tiEx)
            {
                throw tiEx.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    class ProgressInfo
    {
        public Image m_Image;
        public int m_ImageIndex;
              public Image Image
        {
            set { m_Image = value; }
            get { return m_Image; }
        }
        public int ImageIndex
        {
            set { m_ImageIndex = value; }
            get { return m_ImageIndex; }
        }
    }
