    [DataContract]
    public class ContingentOrder
    {
        [DataMember(Order=1)]
        public Guid TriggerDealAssetID;
        [DataMember(Order=2)]
        public decimal TriggerPrice;
        [DataMember(Order=3)]
        public TriggerPriceTypes TriggerPriceType;
        [DataMember(Order=4)]
        public PriceTriggeringConditions PriceTriggeringCondition;
    }
