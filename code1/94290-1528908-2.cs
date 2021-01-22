    public void GenerateThumbNail(HttpPostedFile fil, string sPhysicalPath, 
                                  string sOrgFileName,string sThumbNailFileName,
                                  System.Drawing.Imaging.ImageFormat oFormat, int rez)
    {
        try
        {
            System.Drawing.Image oImg = System.Drawing.Image.FromStream(fil.InputStream);
            decimal pixtosubstract = 0;
            decimal percentage;
            //default
            Size ThumbNailSizeToUse = new Size();
            if (ThumbNailSize.Width < oImg.Size.Width || ThumbNailSize.Height < oImg.Size.Height)
            {
                if (oImg.Size.Width > oImg.Size.Height)
                {
                    percentage = (((decimal)oImg.Size.Width - (decimal)ThumbNailSize.Width) / (decimal)oImg.Size.Width);
                    pixtosubstract = percentage * oImg.Size.Height;
                    ThumbNailSizeToUse.Width = ThumbNailSize.Width;
                    ThumbNailSizeToUse.Height = oImg.Size.Height - (int)pixtosubstract;
                }
                else
                {
                    percentage = (((decimal)oImg.Size.Height - (decimal)ThumbNailSize.Height) / (decimal)oImg.Size.Height);
                    pixtosubstract = percentage * (decimal)oImg.Size.Width;
                    ThumbNailSizeToUse.Height = ThumbNailSize.Height;
                    ThumbNailSizeToUse.Width = oImg.Size.Width - (int)pixtosubstract;
                }
            }
            else
            {
                ThumbNailSizeToUse.Width = oImg.Size.Width;
                ThumbNailSizeToUse.Height = oImg.Size.Height;
            }
            Bitmap bmp = new Bitmap(ThumbNailSizeToUse.Width, ThumbNailSizeToUse.Height);
            bmp.SetResolution(rez, rez);
            System.Drawing.Image oThumbNail = bmp;
            bmp = null;
            Graphics oGraphic = Graphics.FromImage(oThumbNail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, ThumbNailSizeToUse.Width, ThumbNailSizeToUse.Height);
            oGraphic.DrawImage(oImg, oRectangle);
            oThumbNail.Save(sPhysicalPath  + sThumbNailFileName, oFormat);
            oImg.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
