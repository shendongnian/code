       public IAmImage ImageToShow 
       {  
           get  
           {    
               return this.IsWebContext?
                  new StringImage(this.GetString()):        
                  new BitmapImage(this.GetBitmap());    
           }
       } 
      
