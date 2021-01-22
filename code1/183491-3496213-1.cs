    //find the perfect product amount price
    While (qtyRemain != 0) {
    perfectPrice += (qtyRemain % nextSmallestSize) * nextSmallestPackagePrice;
    qtyRemain -= (qtyReamin % nextSmallestSize)
    }
    
    //Find the closest match over price
    While ((qtyRemain % nextSmallestSize) != 0){
    closePrice += (qtyRemain % nextSmallestSize) * nextSmallestPackagePrice;
    qtyRemain -= (qtyRemain % nextSmallestSize)
    }
    //add the last price before we reached the perfect price size
    closePrice += nextSmallestPackagePrice;
    
    //determine lowest price
    if closePrice < perfectPrice {
     cost = closePrice;
    }
    else {
     cost = PerfectPrice;
    }
