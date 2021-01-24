    var Day0Spot = (from a in a1
                     join fx in q
                         on a.CurrencyCodeID equals fx.CurrencyCodeID
                     select new Adjustments()
                     {
                         AdjustmentID = a.AdjustmentID,
                         AdjustmentTypeID = a.AdjustmentTypeID
    				 }).ToList();
    				 
    AdjustmentsList adjustList =new AdjustmentsList(){
    	items = Day0Spot
    };
