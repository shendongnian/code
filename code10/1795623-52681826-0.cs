     /// <summary>
        /// cattura un immagine
        /// </summary>
        /// <returns>The picture.</returns>
        public async Task<byte[]> take_picture()
        {
            pictureTaken = null;
            try
            {
                this.PreviewCamera.StopPreview();
                this.PreviewCamera.TakePicture(new ShutterCameraCallback(),new RawCameraCallback(),new JpegCameraCallback());
                this.PreviewCamera.StartPreview();
                return pictureTaken;
              
            }
            catch(Exception e)
            { Console.WriteLine(e);}
            return null;
        }
