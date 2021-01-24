    public partial class Setting
	{
		public void SendPropertyChangedFromOutside(string propName)
		{
			SendPropertyChanged(propName);
		}
	}
	public partial class User
	{
		public void SendPropertyChangedFromOutside(string propName)
		{
			SendPropertyChanged(propName);
		}
	}
