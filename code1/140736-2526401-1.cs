    public ThumbnailImage GetThumbnailImageByVideoId( long videoId )
    {
        Database db = DatabaseFactory.CreateDatabase("Connection String");
        DataSet ds = new DataSet();
        ThumbnailImage img =  null;
        try
        {
            using (DbCommand cmd = db.GetStoredProcCommand("usp_GetThumbnailImageByVideoId"))
            {
                db.AddInParameter(cmd, "VideoId", DbType.Int64, videoId);                    
                db.LoadDataSet(cmd, ds, "Video");
            }
            foreach (DataRow dr in ds.Tables["Video"].Rows)
            {
                if (! string.IsNullOrEmpty(dr["ThumbnailImage"].ToString()))
                {
                    byte[] b = dr["ThumbnailImage"] as byte[];
                    MemoryStream ms = new MemoryStream(b);
                    img = new ThumbnailImage();
                    img.Image = Image.FromStream(ms);
                    img.ContentType = dr["ImageContentType"].ToString();
                }
                break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return img;
    }
