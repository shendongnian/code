        public ActionResult ViewFile()
        {
            string contentType = "Image/jpeg";
            
            
            byte[] data = this.FileServer("FileLocation");
            if (data == null)
            {
                return this.Content("No picture for this program.");
            }
            return File(data, contentType, img + ".jpg");
        }
