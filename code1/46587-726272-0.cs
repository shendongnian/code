	partial class User
	{
		public string FirstName
		{
			get
			{
				return (string)this.getExtendedProperty("FirstName").Value;
			}
			set
			{
				this.setExtendedProperty("FirstName", value);
			}
		}
		public string LastName
		{
			get
			{
				return (string)this.getExtendedProperty("LastName").Value;
			}
			set
			{
				this.setExtendedProperty("LastName", value);
			}
		}
		private void setExtendedProperty(string KeyName, object Value)
		{
			ExtendedProperty property = this.getExtendedProperty(KeyName);
			property.Value = Value;
		}
		private ExtendedProperty getExtendedProperty(string KeyName)
		{
			return (from prop in this.ExtendedProperties where prop.KeyName == KeyName select prop).Single();
		}
	}
