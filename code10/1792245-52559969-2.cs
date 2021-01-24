    public float GetGrowthFactor(CropType type) 
    {
        var crop = GetCrop(type);
        return crop == null ? default(float) : crop.GrowthFactor;
    }
    public float GetHarvestFactor(CropType type) 
    {
        var crop = GetCrop(type);
        return crop == null ? default(float) : crop.HarvestFactor;
    }
