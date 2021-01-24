    public static TDeal GetDeal<TDeal, TDealInfo>()
        where TDeal : DealBase<TDeal, TDealInfo>
        where TDealInfo : DealInfoBase<TDeal, TDealInfo>
    {
        return new ConcreateDeal(); // <== compiler error
    }
