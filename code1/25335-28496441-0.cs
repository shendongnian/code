    public void SaveMultiFrameTiff(int start, int end)
        {            
            string outputFileName = "out.TIF";  
            string inputFileName = "input.TIF";            
            try
            {                
                Bitmap MasterBitmap = new Bitmap(inputFileName ); //Start page of document(master)
                Image imageAdd = Image.FromFile(inputFileName );  //Frame Image that will be added to the master          
                Guid guid = imageAdd.FrameDimensionsList[0]; //GUID
                FrameDimension dimension = new FrameDimension(guid);
                // start index cannot be less than 0 and cannot be greater than frame count        
                if (start < 1 || end > MasterBitmap.GetFrameCount(dimension)) { return; }        
                EncoderParameters ep = new EncoderParameters(1);
                //Get Image Codec Information
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo codecInfo = codecs[3]; //image/tiff
                //MultiFrame Encoding format
                EncoderParameter epMultiFrame = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
                ep.Param[0] = epMultiFrame;
                MasterBitmap.SelectActiveFrame(dimension, start - 1);
                MasterBitmap.Save(outputFileName, codecInfo, ep);//create master document
                //FrameDimensionPage Encoding format
                EncoderParameter epFrameDimensionPage = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
                ep.Param[0] = epFrameDimensionPage;
                for (int i = start; i < end; i++)
                {
                    imageAdd.SelectActiveFrame(dimension, i);//select next frame
                    MasterBitmap.SaveAdd(new Bitmap(imageAdd), ep);//add it to the master
                }
                //Flush Encoding format
                EncoderParameter epFlush = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush);
                ep.Param[0] = epFlush;
                MasterBitmap.SaveAdd(ep); //flush the file                   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
