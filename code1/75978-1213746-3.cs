    (dea.Data as System.Runtime.InteropServices.ComTypes.IDataObject).GetData(ref formatEtc, out stgMedium);
    Bitmap remotingImage = Bitmap.FromHbitmap(stgMedium.unionmember);
    
    (sender as PictureBox).Image = remotingImage;
  
