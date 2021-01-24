	if(device.WeightLB == null)
	{
		value = string.Empty;
	}
	else if(GlobalVariables.MeasurementId == 1)
	{
		value = FormatHelper.BuildDecimal(device.WeightKG) + Constants.KgUnit;
	}
	else
	{
		value = FormatHelper.BuildDecimal(device.WeightLB) + Constants.LbUnit;
	}
