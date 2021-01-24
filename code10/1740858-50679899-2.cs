    private List<ImageUrl> GetImageNames()
    {
        String mediaServerFilePath = Helper.GetMediaDomain();
        String[] path = HttpContext.Current.Request.UrlReferrer.ToString().Split('/');
        String FolderName = path.Last().Replace(".htm", "");
        String languageCode = Helper.CurrencyCode;
        String images = mediaServerFilePath + "/Assets/img/DepositHelp/Banner" + "/" + languageCode + "/" + FolderName + "/" + "*.jpg";
        List<ImageUrl> ImageUrlList = new List<ImageUrl>();
        foreach (Char image in images)
        {
            ImageUrlList.Add(new ImageUrl {Name = mediaServerFilePath + "/Assets/img/DepositHelp/Banner" + "/" + languageCode + "/" + FolderName + "/" + image + ".jpg"});
        }
    }
