    /*
       The refresh token and all the values represented by constans are given when you allow the application in your imgur panel on the response url
    */
        
    public OAuth2Token CreateToken()
    {
        var token = new OAuth2Token(TOKEN_ACCESS, REFRESH_TOKEN, TOKEN_TYPE, ID_ACCOUNT, IMGUR_USER_ACCOUNT, int.Parse(EXPIRES_IN));
        return token;
    }
    //Use it only if your token is expired
    public Task<IOAuth2Token> RefreshToken()
    {
        var client = new ImgurClient(CLIENT_ID, CLIENT_SECRET);
        var endpoint= new OAuth2Endpoint(client);
        var token = endpoint.GetTokenByRefreshTokenAsync(REFRESH_TOKEN);
        return token;
    }
        
    public async Task UploadImage()
    {
         try
         {
              var client = new ImgurClient(CLIENT_ID, CLIENT_SECRET, CreateToken());
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
