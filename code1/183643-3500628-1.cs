    Object imageLock = new Object();
    try
    {
           while ((t < (time * 60 * 1000)) && !done)
           {
              lock (imageLock)
              {
              image.Save(folder + this.filename + DateTime.Now.ToString("yyyMMddHHmmssFFFFFFF") + ".jpg", ImageFormat.Jpeg);
              }
              t = t + interval;
              System.Threading.Thread.Sleep(interval);
              i++;
           }
    }
    catch (Exception e)
    {
      Console.WriteLine("Exception: " + e.Message);
      Console.WriteLine("Stack trace: " + e.StackTrace);
    } 
