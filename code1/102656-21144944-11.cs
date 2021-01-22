	public partial class MyRandomClass: IAutoNotifyPropertyChanged
	{
		public void WhenPropertyChanges(string propertyName)
		{
			switch (propertyName)
			{
				case "field1": this.field1Specified = true; return;
				// etc
			}
		}
	}
