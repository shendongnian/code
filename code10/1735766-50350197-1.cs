    private string Calculate(Device device)
    {
        if (device.WeightLB == null)
            return string.Empty;        
        
        return GlobalVariables.MeasurementId == 1 ? 
                device.WeightKG.BuildDecimal().ToKgUnit(): 
                device.WeightLb.BuildDecimal().ToLbUnit();
    }
    //Extension implementation
    public static class  MyExtensions
    {
        public static decimal BuildDecimal(this string value)
        {
            return FormatHelper.BuildDecimal(value);
        }
        public static string ToKgUnit(this decimal value)
        {
            return value+Constants.KgUnit;
        }
        public static string ToLbUnit(this decimal value)
        {
            return value+Constants.LbUnit;
        }
    }
