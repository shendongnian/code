    [HttpPost]
    public ActionResult CoverPhoto(string thumb_values)
    {
            var ImageCode = thumb_values.Split(',');
            var imagepart = ImageCode[1];
            imagepart = imagepart.Replace('"', ' ');
            byte[] imageBytes = Convert.FromBase64String(imagepart);
            System.IO.File.WriteAllBytes(@"F:\TestFolder\img.jpg" , imageBytes ); 
            return View();
    }
