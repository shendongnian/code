    // untested
    void LoadImages()
    {
           // this.Dispatcher.Invoke(DispatcherPriority.Normal, 
           //    new System.Windows.Forms.MethodInvoker(delegate() {
        IService1 svc = ConnectAndGetObject();
        foreach (byte[] imgbytes in svc.GetImageDateWise(datePicker1.DisplayDate, DateTime.Now, "test"))
        {   
            using (MemoryStream mem = new MemoryStream(imgbytes))
            {    
                BitmapImage jpgimage = new BitmapImage();
                // jpgimage.BeginInit();    
                jpgimage.CacheOption = BitmapCacheOption.OnLoad;    
                jpgimage.StreamSource = mem;    
                // jpgimage.EndInit();
    
                Image wpfimage = new Image();
                wpfimage.Source = jpgimage.Clone();
                // only invoke the part actually touching the UI    
                this.Dispatcher.Invoke(DispatcherPriority.Normal, 
                  new System.Windows.Forms.MethodInvoker(delegate() {
                      lbx.Items.Add(wpfimage);
                      lbx.UpdateLayout();   } ));
                  
                Thread.Sleep(1000);
            }
        }    
       //  }));
    }
