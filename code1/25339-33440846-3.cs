    /// <summary>
        /// Takes in an array of base64 encoded strings and creates a multipage tiff.
        /// </summary>
        /// <param name="sOutFile">file to be generated</param>
        /// <param name="pagesbase64Array"></param>
        private void SaevAsMultiPageTiff(string sOutFile, string[] pagesbase64Array)
        {
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.SaveFlag;
            ImageCodecInfo encoderInfo = ImageCodecInfo.GetImageEncoders().First(i => i.MimeType == "image/tiff");
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
            Bitmap firstImage = null;
            try
            {
                using (MemoryStream ms1 = new MemoryStream())
                {
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(pagesbase64Array[0])))
                    {
                        Image.FromStream(ms).Save(ms1, ImageFormat.Tiff);
                        firstImage = (Bitmap)Image.FromStream(ms1);
                    }
                    // Save the first frame of the multi page tiff
                    firstImage.Save(sOutFile, encoderInfo, encoderParameters); //throws Generic GDI+ error if the memory streams are not open when this is called
                }
                
                encoderParameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionPage);
                Bitmap imagePage;
                // Add the remining images to the tiff
                for (int i = 1; i < pagesbase64Array.Length; i++)
                {
                    using (MemoryStream ms1 = new MemoryStream())
                    {
                        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(pagesbase64Array[i])))
                        {
                            Image.FromStream(ms).Save(ms1, ImageFormat.Tiff);
                            imagePage = (Bitmap)Image.FromStream(ms1);
                        }
                        
                        firstImage.SaveAdd(imagePage, encoderParameters); //throws Generic GDI+ error if the memory streams are not open when this is called
                    }
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
