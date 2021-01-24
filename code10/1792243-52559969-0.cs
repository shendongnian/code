    private enum CropType
    {
        Undefined = 0,
        Cabbages,
        Carrots,
        Eggplant,
        Melon,
        Mushroom,
        Potatoes,
        Pumpkin,
        Strawberries,
        Truffle,
        Wheat
    }
    private struct Crop
    {
        public CropType Type { get; private set; }
        public float GrowthFactor { get; private set; }
        public float HarvestFactor { get; private set; }
        public Crop(CropType type, float growthFactor, float harvestFactor) 
        {
            this.Type = type;
            this.GrowthFactor = growthFactor;
            this.HarvestFactor = harvestFactor;
        }
    }
