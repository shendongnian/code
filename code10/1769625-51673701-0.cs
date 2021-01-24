    // NUnit
    Assert.Throws<RuntimeBinderException>(() => serviceResult.Result.LOCATION_AMOUNT);
    Assert.Throws<RuntimeBinderException>(() => serviceResult.Result.VAT_AMOUNT);    
    Assert.Throws<RuntimeBinderException>(() => serviceResult.Result.LOCATION_AMOUNT);
    // MSTest
    ExceptionAssert.Throws(() => serviceResult.Result.LOCATION_AMOUNT);
    ExceptionAssert.Throws(() => serviceResult.Result.VAT_AMOUNT);    
    ExceptionAssert.Throws(() => serviceResult.Result.LOCATION_AMOUNT);
