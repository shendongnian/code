     // open a multi page tiff using a Stream
     using(Stream stream = // your favorite stream depending if you have in memory or from file.)
     {
     Bitmap bmp = new Bitmap(imagePath);
     int frameCount = bmp.GetFrameCount(FrameDimension.Page);
     // for a reference for creating a new multi page tiff see: 
     // http://www.bobpowell.net/generating_multipage_tiffs.htm
     // Here all the stuff of the Encoders, and all that stuff.
     EncoderParameters ep = new EncoderParameters(1);
     ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
     Image newTiff = theNewFirstImage;
     for(int i=0; i<frameCount; i++)
     {
         if(i==0)
         {
              // Just save the new image instead of the first one.
              newTiff.Save(newFileName, imageCodecInfo, Encoder);
         }
         else
         {
              Bitmap newPage = bmp.SelectActiveFrame(FrameDimension.Page);
              newTiff.SaveAdd(newPage, ep);
         }
     }
     
     ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
     newTiff.SaveAdd(ep);
     }
     // close all files and Streams and the do original file delete, and newFile change name... 
