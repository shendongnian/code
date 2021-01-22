      public static void GetPictureSize(string url, ref float width, ref float height, ref string err)
      {
        System.Net.HttpWebRequest wreq;
        System.Net.HttpWebResponse wresp;
        System.IO.Stream mystream;
        System.Drawing.Bitmap bmp;
        bmp = null;
        mystream = null;
        wresp = null;
        try
        {
            wreq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            wreq.AllowWriteStreamBuffering = true;
            wresp = (HttpWebResponse)wreq.GetResponse();
            if ((mystream = wresp.GetResponseStream()) != null)
                bmp = new System.Drawing.Bitmap(mystream);
        }
        catch (Exception er)
        {
            err = er.Message;
            return;
        }
        finally
        {
            if (mystream != null)
                mystream.Close();
            if (wresp != null)
                wresp.Close();
        }
        width = bmp.Width;
        height = bmp.Height;
    }
    public static bool ImageUrlExists(string url)
    {
        float width = 0;
        float height = 0;
        string err = null;
        GetPictureSize(url, ref width, ref height, ref err);
        return width > 0;
    }
