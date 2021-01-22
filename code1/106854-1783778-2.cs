    private void LoadImage(string filename, ref Image image)
    {
      using (MemoryStream memoryStream = DecryptImageBinary(Settings.Default.ImagePath + filename, _cryptPassword))
      {
          using (tmpImage = Image.FromStream(memoryStream))
          { 
             image = new Bitmap(tmpImage);
          }
      }
    }
