    private List<ImageObj> images;
    public List<ImageObj> Images
    {
         get { return images; }
         private set { SetProperty(ref images, value); }
    }
    
    private async Task DisplayImages()
    {
        Images = await _mediaService.GetCatImages()
                                    .Select(x => x.Hit)
                                    .ToList();
    }
