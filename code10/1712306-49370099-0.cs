    private <TYPE> _CashActivityTypeSelected;
    public <TYPE> CashActivityTypeSelected 
    {
    get
     {
       return _CashActivityTypeSelected;
     }
    set
    {
      _CashActivityTypeSelected=value; 
      FilterMySecondCollectionView(value);
     };
