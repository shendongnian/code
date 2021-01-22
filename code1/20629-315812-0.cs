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
            string[] knownPicExtensions = {".jpg",".gif",
