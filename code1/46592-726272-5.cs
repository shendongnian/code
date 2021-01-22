partial class User
{
	public string FirstName
	{
		get { return (string)this.getExtendedProperty("FirstName").Value; }
		set { this.getExtendedProperty("FirstName").Value = value; }
	}
	public string LastName
	{
		get { return (string)this.getExtendedProperty("LastName").Value; }
		set { this.getExtendedProperty("LastName").Value = value; }
	}
	// Grab a related property out of the collection, any changes to it will be reflected in the database after a submit
	private ExtendedProperty getExtendedProperty(string KeyName)
	{
		// grab the properties that fit the criterea
		var properties = (from prop in this.ExtendedProperties where prop.KeyName == KeyName select prop);
		// return value
		ExtendedProperty property = properties.SingleOrDefault();
		
		// if this is a new user then there arent going to be any properties that match
		if (property == null)
		{
			// Define a new item to add to the collection
			property = new ExtendedProperty()
			{
				ItemID = this.UserID,
				KeyName = KeyName,
				Value = String.Empty
			};
			// Add the item we're about to return to the collection
			this.ExtendedProperties.Add(property);
		}
		
		// either way we have a valid property to return at this point
		return property;
	}
}
