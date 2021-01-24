    protected void cmdSave_Click(object sender, EventArgs e)
        {
            string str = Request.Form["ImageData"];
            SaveImg(str);
        }
        public  bool SaveImg(string str)
        {
            try
            {
                string imageData = str.Replace("data:image/png;base64,", "");
                var bytes = Convert.FromBase64String(imageData);
                string filePath = @"C:\Windows\Temp\File.jpg";
                if (File.Exists(filePath)) File.Delete(filePath);
                using (var imageFile = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
                return false;
            }
            catch (Exception Ex)
            {           
                    return true;
            }
        }
