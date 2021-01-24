    double TotalFrame;
    int FrameNo = 1;
    bool IsReadingFrame;
    VideoCapture capture;
     
    System.Windows.Forms.ImageList myImageList = new ImageList();
    public Form1()
    {
      InitializeComponent();
      listViewFile.LargeImageList = myImageListLarge;
	
	  if (capture==null)
      {
        return;
      }
      IsReadingFrame = true;
      ReadAllFrames();
    }
    private async void ReadAllFrames()
    {
      Mat m = new Mat();
      while (IsReadingFrame == true && FrameNo <= TotalFrame)
      {
        listViewFile.Items.Add(new ListViewItem { ImageIndex = FrameNo, Text = 
        FrameNo.ToString() });
        capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, FrameNo);
        capture.Read(m);
        pictureBox1.Image = m.Bitmap;
        myImageList.ImageSize = new Size(80, 80);
        myImageList.Images.Add(m.Bitmap);
                
        listViewFile.LargeImageList = myImageList;
      }
    }
    
