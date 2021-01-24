     public string GetImage(string file)
        {
            string imgPath = Server.MapPath("~/Content/UserImages/Originals/" + file);
            byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
            string imreBase64Data = Convert.ToBase64String(byteData);
            string imgDataURL = string.Format("data:image/jpg;base64,{0}", imreBase64Data);
            return imgDataURL;
        }
