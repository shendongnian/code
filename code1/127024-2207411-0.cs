    class ImageManager
    {
      private Dictionary<string, Image> images=
        new Dictionary<string,Image>();
    
      public Image get(string s) {  // blocking call, returns the image
        return load(s);
      }
    
      private Image load(string s) {  // internal, thread-safe helper
        lock(images) {
          if(!images.ContainsKey(s)) {
            Image img=// load the image s
            images.Add(s,img);
            return img; 
          }
          return images[s];
        }
      }
    
      public void preload(params string[] imgs) {  // non-blocking preloading call
        foreach(string img in imgs) { 
          BackgroundWorker bw=new BackgroundWorker();
          bw.DoWork+=(s,e)=>{ load(img); }  // discard the actual image return
          bw.RunWorkerAsync();
        }
      }
    }
    
    // in your main function
    {
       ImageManager im=new ImageManager();
       im.preload("path1", "path2", "path3", "path4"); // non-blocking call
       
       // then you just request images based on their path
       // they'll become available as they are loaded
       // or if you request an image before it's queued to be loaded asynchronously 
       // it will get loaded synchronously instead, thus with priority because it's needed
    }
