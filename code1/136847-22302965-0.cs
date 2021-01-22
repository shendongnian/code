    using (ShimsContext.Create())
    {
       System.Fakes.ShimDateTime.NowGet = () => new DateTime(2014, 3, 10);
       MethodThatUsesDateTimeNow();
    }
