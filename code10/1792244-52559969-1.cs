    private Dictionary<CropType, Crop> crops;
    private Dictionary<CropType, Crop> Crops 
    {
        get 
        {
            if (crops == null) 
            {
                crops = new Dictionary<CropType, Crop>() 
                {
                    { CropType.Cabbages, new Crop(CropType.Cabbages, 90, 1) },
                    { CropType.Carrots, new Crop(CropType.Carrots, 80, 5) }
                    // here you can add the rest of your products...
                };
            }
            return crops;
        }
    }
    public Crop GetCrop(CropType crop) 
    {
        if (!Crops.ContainsKey(type)) 
        {
            Debug.LogWarningFormat("GetCrop; CropType [{0}] not present in dictionary ", type);
            return null;
        }
        return Crops[type];
    }
