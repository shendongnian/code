       public IAmImage ImageToShow 
       {  
           get  
           {    
               if(this.IsWebContext) 
                  return new StringImage(this.GetString());        
               else 
                  return new BitmapImage(this.GetBitmap());    
           }
       } 
      
