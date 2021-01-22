public void UpdatePhoto(Binary photo)
        {
            if (InvokeRequired)
            {
                var d = new UpdatePhotoDelegate(UpdatePhoto);
                Invoke(d, new object[] { photo});
            }
            else
            {
                if (photo != null)
                {
                    var ms = new MemoryStream(photo.ToArray());
                    var bmp = new Bitmap(ms);
                    pbPhoto.BackgroundImage = bmp;
                }
            }
        }
