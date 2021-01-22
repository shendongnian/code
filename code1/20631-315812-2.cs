     protected void MethodToBeCalled()
        {
    
        
            System.Drawing.Image[] cards = Directory.GetFiles(cardsFolder).Where(
                  f =>
                  {
                      
                      if (IsImage((string)f))
                      {
                          return true ;
                      }
                      else { return false; }
                  }
                ).Select(f => System.Drawing.Image.FromFile(f)).ToArray();
    
        }
            private bool IsImage(string filename)
        {
            string[] knownPicExtensions = {".jpg",".gif",".png",".bmp",".jpeg",".jpe" };
    
            foreach (string extension in knownPicExtensions)
            {
                if (filename.ToLower().EndsWith(extension))
                    return true;
            }
    
            return false;
        }
