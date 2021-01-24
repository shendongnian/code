    private double _BrewAmount = 10;
	public double BrewAmount
	{
		get { return _BrewAmount; }
		set
		{
			CorrectedBrewAmount = value.ToString();
		}
	} // In database. Holds the volume in liters, no matter the ComboBox unit selection.
	private string _CorrectedBrewAmount = "0";
	public string CorrectedBrewAmount
	{
		get
		{
			string[] Result = Convert.VolumeFromLiterWithUnitConversion(BrewAmount, BrewAmountSelectedIndex == -1 ? AppSettings.MeasuringSystem == MeasuringSystem.Systems[MeasuringSystem.Metric] ? LiquidUnit.Liter : LiquidUnit.Gallon : BrewAmountSelectedIndex);
			_CorrectedBrewAmount = Result[0];
			return Result[0];
		}
		set
		{
			_BrewAmount = Convert.VolumeToLiter(System.Convert.ToDouble(value), BrewAmountSelectedIndex == -1 ? AppSettings.MeasuringSystem == MeasuringSystem.Systems[MeasuringSystem.Metric] ? LiquidUnit.Liter : LiquidUnit.Gallon : BrewAmountSelectedIndex);
			NotifyPropertyChanged("CorrectedBrewAmount");
		}
	}	// Not in database. The value shown in the TextBox.
	private int _BrewAmountSelectedIndex = -1;
	public int BrewAmountSelectedIndex
	{
		get	{ return _BrewAmountSelectedIndex; }
		set
		{
			_BrewAmountSelectedIndex = value;
			_BrewAmount = Convert.VolumeToLiter(System.Convert.ToDouble(_CorrectedBrewAmount), value == -1 ? LiquidUnit.Liter : value);
			NotifyPropertyChanged("BrewAmountSelectedIndex");
		}
	} // Not in database. The bindable selected index.
