    // Version 1
    [Serializable]
    public class SerializableContingentOrder
    {
        public Guid TriggerDealAssetID;
        public decimal TriggerPrice;
        public TriggerPriceTypes TriggerPriceType;
        // Omitted PriceTriggeringCondition as an example
    }
    // Version 2 
    [Serializable]
    public class SerializableContingentOrder
    {
        public Guid TriggerDealAssetID;
        public decimal TriggerPrice;
        public TriggerPriceTypes TriggerPriceType;
        
        [OptionalField(VersionAdded = 2)]
        public PriceTriggeringConditions PriceTriggeringCondition;
        [OnDeserializing]
        void SetCountryRegionDefault (StreamingContext sc)
        {
            PriceTriggeringCondition = /* DEFAULT VALUE */;
        }
    }
