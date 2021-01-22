    for (int i = 0; i < NumbersOfImg; i++)
    {
        if (i < ImgObjArr.Count)
        {
            ThreadPool.QueueUserWorkItem(getUrlImg)
        }
    }
     private void getUrlImg(object state)
     {
         MyImage mycurrentImg = (MyImage)ImgObjArr[currentMyImg];
         if (currentMyImg < ImgObjArr.Count - 1)
             currentMyImg++;
         myRequest = (HttpWebRequest)WebRequest.Create(mycurrentImg.ImageLink);
         myResponse = (HttpWebResponse)myRequest.GetResponse();
         Stream ImgStream = myResponse.GetResponseStream();
         mycurrentImg.FullImg = new Bitmap(ImgStream);
         this.BeginInvoke(new EventHandler(ImageUpdate));
    }
