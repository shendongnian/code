    public async Task UploadImage()
    {
        try
        {
            var client = new ImgurClient("CLIENT_ID", "CLIENT_SECRET");
            var endpoint = new ImageEndpoint(client);
            IImage image;
            //Here you have to link your image location
            using (var fs = new FileStream(@"IMAGE_LOCATION", FileMode.Open))
            {
                image = await endpoint.UploadImageStreamAsync(fs);
            }
            Debug.Write("Image uploaded. Image Url: " + image.Link);
        }
        catch (ImgurException imgurEx)
        {
            Debug.Write("Error uploading the image to Imgur");
            Debug.Write(imgurEx.Message);
        }
    }
