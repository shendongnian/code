    public HttpResponseMessage  PostSealCryptItem([FromBody]String base64)
    {
        MyImage myImg = createImg(base64);
        Image img = convertMyImgToImage(myImg);
        using(MemoryStream ms = new MemoryStream())
        {
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(ms.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
    
            return result;
        }
    }
