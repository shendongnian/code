    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private Boolean CheckFileType(String fileName)
        {
            String ext = Path.GetExtension(fileName) ;
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".bmp":
                    return true;
                default:
                    return false;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            const int bmpW = 300;// //New image target width
            const int bmpH = 226;// //New Image target height
            if (FileUpload1.HasFile)
            {
                //Clear the error label text 
                lblError.Text = "";
                //Check to make sure the file to upload has a picture file format extention 
                //and set the target width and height
                if (this.CheckFileType(FileUpload1.FileName))
                {
                    Int32 newWidth = bmpW;
                    Int32 newHeight = bmpH;
                    //Use the uploaded filename for saving without the "." extension
                    String upName = FileUpload1.FileName.Substring(0, FileUpload1.FileName.IndexOf("."));
                    //Mid(FileUpload1.FileName, 1, (InStr(FileUpload1.FileName, ".") - 1)) ;
                    //Set the save path of the resized image, you will need this directory already created in your web site
                    String filePath = "~/Upload/" + upName + ".jpg";
                    //Create a new Bitmap using the uploaded picture as a Stream 
                    //Set the new bitmap resolution to 72 pixels per inch
                    Bitmap upBmp = (Bitmap)Bitmap.FromStream(FileUpload1.PostedFile.InputStream);
                    Bitmap newBmp = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    newBmp.SetResolution(72, 72);
                    //Get the uploaded image width and height
                    Int32 upWidth = upBmp.Width;
                    Int32 upHeight = upBmp.Height;
                    Int32 newX = 0; //Set the new top left drawing position on the image canvas
                    Int32 newY = 0;
                    Decimal reDuce;
                    //Keep the aspect ratio of image the same if not 4:3 and work out the newX and newY positions 
                    //to ensure the image is always in the centre of the canvas vertically and horizontally
                    if (upWidth > upHeight)
                    {
                        //Landscape picture
                        reDuce = newWidth / upWidth;
                        //calculate the width percentage reduction as decimal
                        newHeight = ((Int32)(upHeight * reDuce));
                        //reduce the uploaded image height by the reduce amount
                        newY = ((Int32)((bmpH - newHeight) / 2));
                        //Position the image centrally down the canvas
                        newX = 0; //Picture will be full width 
                    }
                    else
                    {
                        if (upWidth < upHeight)
                        {
                            //Portrait picture
                            reDuce = newHeight / upHeight;
                            //calculate the height percentage reduction as decimal
                            newWidth = ((Int32)(upWidth * reDuce));
                            //reduce the uploaded image height by the reduce amount
                            newX = ((Int32)((bmpW - newWidth) / 2));
                            //Position the image centrally across the canvas
                            newY = 0; //Picture will be full hieght 
                        }
                        else
                        {
                            if (upWidth == upHeight)
                            {
                                //square picture
                                reDuce = newHeight / upHeight;
                                //calculate the height percentage reduction as decimal
                                newWidth = ((Int32)((upWidth * reDuce)));
                                //reduce the uploaded image height by the reduce amount
                                newX = ((Int32)(((bmpW - newWidth) / 2))); //Position the image centrally across the canvas
                                newY = ((Int32)(((bmpH - newHeight) / 2))); //Position the image centrally down the canvas
                            }
                        }
                    }
                    //Create a new image from the uploaded picture using the Graphics class
                    //Clear the graphic and set the background colour to white
                    //Use Antialias and High Quality Bicubic to maintain a good quality picture
                    //Save the new bitmap image using //Png// picture format and the calculated canvas positioning
                    Graphics newGraphic = Graphics.FromImage(newBmp);
                    try
                    {
                        newGraphic.Clear(Color.White);
                        newGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        newGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        newGraphic.DrawImage(upBmp, newX, newY, newWidth, newHeight);
                        newBmp.Save(MapPath(filePath), System.Drawing.Imaging.ImageFormat.Jpeg);
                        //Show the uploaded resized picture in the image control
                        Image1.ImageUrl = filePath;
                        Image1.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.ToString();
                        throw ex;
                    }
                    finally
                    {
                        upBmp.Dispose();
                        newBmp.Dispose();
                        newGraphic.Dispose();
                    }
                }
                else
                {
                    lblError.Text = "Please select a picture with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png.";
                }
            }
        }
    }
