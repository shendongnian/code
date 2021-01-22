    using (TempConvertService TMPConSvc =
    new TempConvertService.TempConvertServiceClient())
    {
    result = TMPConSvc.ConvertToF(32.00);
    return result;
    }
