    /// <summary>
        /// Takes in an array of base64 encoded strings and creates a multipage tiff.
        /// </summary>
        /// <param name="sOutFile">file to be generated</param>
        /// <param name="pagesbase64Array"></param>
        private void SaevAsMultiPageTiff(string sOutFile, string[] pagesbase64Array)
        {
            img.Encoder encoder = img.Encoder.SaveFlag;
            ImageCodecInfo encoderInfo = ImageCodecInfo.GetImageEncoders().First(i => i.MimeType == "image/tiff");
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
            Bitmap firstImage = null;
            try
            {
                // Save the first frame of the multi page tiff
                
                firstImage = (Bitmap)getBitMap(pagesbase64Array[0]);
                firstImage.Save(sOutFile, encoderInfo, encoderParameters);
                encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionPage);
                // Add the remining images to the tiff
                for (int i = 1; i < pagesbase64Array.Length; i++)
                {
                    Bitmap img = (Bitmap)getBitMap(pagesbase64Array[i]);
                    firstImage.SaveAdd(img, encoderParameters);
                }
                
            }
            catch (Exception)
            {
                //ensure the errors are not missed while allowing for flush in finally block so files dont get locked up.
                throw;
            }
            finally
            {
                // Close out the file
                encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
                firstImage.SaveAdd(encoderParameters);
            }
            
            
            
        }
        private Image getBitMap(string sbase64Array)
        {
            Image streamImage;
            
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(sbase64Array)))
            {
                using (MemoryStream ms1 = new MemoryStream())
                {
                    //Seems to need this extra saving of memory stream in tiff format for this to work
                    Image.FromStream(ms).Save(ms1, ImageFormat.Tiff);
                    streamImage = Image.FromStream(ms1);
                }
            }
            return streamImage;
        }
    
