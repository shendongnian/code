    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    namespace Pariwaar.Controller
    {
        public class imageResize
        {
    
            public byte[] ResizeFromByteArray(int MaxSideSize, Byte[] byteArrayIn, string fileName)
            {
                byte[] byteArray = null;  // really make this an error gif
                MemoryStream ms = new MemoryStream(byteArrayIn);
                byteArray = this.ResizeFromStream(MaxSideSize, ms, fileName);
    
                return byteArray;
            }
    
            /// <summary>
            /// converts stream to bytearray for resized image
            /// </summary>
            /// <param name="MaxSideSize"></param>
            /// <param name="Buffer"></param>
            /// <returns></returns>
            public byte[] ResizeFromStream(int MaxSideSize, Stream Buffer, string fileName)
            {
                byte[] byteArray = null;  // really make this an error gif
    
                try
                {
    
                    Bitmap bitMap = new Bitmap(Buffer);
                    int intOldWidth = bitMap.Width;
                    int intOldHeight = bitMap.Height;
    
                    int intNewWidth;
                    int intNewHeight;
    
                    int intMaxSide;
    
                    if (intOldWidth >= intOldHeight)
                    {
                        intMaxSide = intOldWidth;
                    }
                    else
                    {
                        intMaxSide = intOldHeight;
                    }
    
                    if (intMaxSide > MaxSideSize)
                    {
                        //set new width and height
                        double dblCoef = MaxSideSize / (double)intMaxSide;
                        intNewWidth = Convert.ToInt32(dblCoef * intOldWidth);
                        intNewHeight = Convert.ToInt32(dblCoef * intOldHeight);
                    }
                    else
                    {
                        intNewWidth = intOldWidth;
                        intNewHeight = intOldHeight;
                    }
    
                    Size ThumbNailSize = new Size(intNewWidth, intNewHeight);
                    System.Drawing.Image oImg = System.Drawing.Image.FromStream(Buffer);
                    System.Drawing.Image oThumbNail = new Bitmap(ThumbNailSize.Width, ThumbNailSize.Height);
    
                    Graphics oGraphic = Graphics.FromImage(oThumbNail);
                    oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                    oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                    oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    Rectangle oRectangle = new Rectangle
                        (0, 0, ThumbNailSize.Width, ThumbNailSize.Height);
    
                    oGraphic.DrawImage(oImg, oRectangle);
    
                    MemoryStream ms = new MemoryStream();
                    oThumbNail.Save(ms, ImageFormat.Jpeg);
                    byteArray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));
    
                    oGraphic.Dispose();
                    oImg.Dispose();
                    ms.Close();
                    ms.Dispose();
                }
                catch (Exception)
                {
                    int newSize = MaxSideSize - 20;
                    Bitmap bitMap = new Bitmap(newSize, newSize);
                    Graphics g = Graphics.FromImage(bitMap);
                    g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, newSize, newSize));
    
                    Font font = new Font("Courier", 8);
                    SolidBrush solidBrush = new SolidBrush(Color.Red);
                    g.DrawString("Failed File", font, solidBrush, 10, 5);
                    g.DrawString(fileName, font, solidBrush, 10, 50);
    
                    MemoryStream ms = new MemoryStream();
                    bitMap.Save(ms, ImageFormat.Jpeg);
                    byteArray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));
    
                    ms.Close();
                    ms.Dispose();
                    bitMap.Dispose();
                    solidBrush.Dispose();
                    g.Dispose();
                    font.Dispose();
    
                }
                return byteArray;
            }
    
            /// <summary>
            /// Saves the resized image to specified file name and path as JPEG
            /// and also returns the bytearray for any other use you may need it for
            /// </summary>
            /// <param name="MaxSideSize"></param>
            /// <param name="Buffer"></param>
            /// <param name="fileName">No Extension</param>
            /// <param name="filePath">Examples: "images/dir1/dir2" or "images" or "images/dir1"</param>
            /// <returns></returns>
            public byte[] SaveFromStream(int MaxSideSize, Stream Buffer, string ErrorMessage, string filePath, string ThumbnailPath)
            {
                byte[] byteArray = null;  // really make this an error gif
    
                try
                {
    
                    Bitmap bitMap = new Bitmap(Buffer);
                    int intOldWidth = bitMap.Width;
                    int intOldHeight = bitMap.Height;
    
                    int intNewWidth;
                    int intNewHeight;
    
                    int intMaxSide;
    
                    if (intOldWidth >= intOldHeight)
                    {
                        intMaxSide = intOldWidth;
                    }
                    else
                    {
                        intMaxSide = intOldHeight;
                    }
    
                    if (intMaxSide > MaxSideSize)
                    {
                        //set new width and height
                        double dblCoef = MaxSideSize / (double)intMaxSide;
                        intNewWidth = Convert.ToInt32(dblCoef * intOldWidth);
                        intNewHeight = Convert.ToInt32(dblCoef * intOldHeight);
                    }
                    else
                    {
                        intNewWidth = intOldWidth;
                        intNewHeight = intOldHeight;
                    }
    
                    Size ThumbNailSize = new Size(intNewWidth, intNewHeight);
                    System.Drawing.Image oImg = System.Drawing.Image.FromStream(Buffer);
                    System.Drawing.Image oThumbNail = new Bitmap(ThumbNailSize.Width, ThumbNailSize.Height);
    
                    Graphics oGraphic = Graphics.FromImage(oThumbNail);
    
                    oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                    oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                    oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    Rectangle oRectangle = new Rectangle
                        (0, 0, ThumbNailSize.Width, ThumbNailSize.Height);
    
                    oGraphic.DrawImage(oImg, oRectangle);
    
                    //Save File
                    string newFileName = filePath;
                    oThumbNail.Save(newFileName, ImageFormat.Jpeg);
    
                    MemoryStream ms = new MemoryStream();
                    oThumbNail.Save(ms, ImageFormat.Jpeg);
                   
                    //--- done by vrunda create thmbnail
                    System.Drawing.Image.GetThumbnailImageAbort dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                    System.Drawing.Image thumbNailImg =oThumbNail.GetThumbnailImage(100, 100, dummyCallBack, IntPtr.Zero);
                    thumbNailImg.Save(ThumbnailPath, ImageFormat.Jpeg);
                    //----- done by vrunda
    
                    byteArray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));
    
                    oGraphic.Dispose();
                    oImg.Dispose();
                    ms.Close();
                    ms.Dispose();
                }
                catch (Exception)
                {
                    int newSize = MaxSideSize - 20;
                    Bitmap bitMap = new Bitmap(newSize, newSize);
                    Graphics g = Graphics.FromImage(bitMap);
                    g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, newSize, newSize));
    
                    Font font = new Font("Courier", 8);
                    SolidBrush solidBrush = new SolidBrush(Color.Red);
                    g.DrawString("Failed To Save File or Failed File  ", font, solidBrush, 10, 5);
                    g.DrawString(ErrorMessage, font, solidBrush, 10, 50);
    
                    MemoryStream ms = new MemoryStream();
                    bitMap.Save(ms, ImageFormat.Jpeg);
                    byteArray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));
    
                    ms.Close();
                    ms.Dispose();
                    bitMap.Dispose();
                    solidBrush.Dispose();
                    g.Dispose();
                    font.Dispose();
    
                }
                return byteArray;
            }
            public bool ThumbnailCallback()
            {
                return false;
            }
    
        }
    }
