		SmtpClient client = new SmtpClient();
		...
		// Add "~" support for pickupdirectories.
		if (client.DeliveryMethod == SmtpDeliveryMethod.SpecifiedPickupDirectory && client.PickupDirectoryLocation.StartsWith("~"))
		{
			string root = AppDomain.CurrentDomain.BaseDirectory;
			string pickupRoot = client.PickupDirectoryLocation.Replace("~/", root);
			pickupRoot = pickupRoot.Replace("/",@"\");
			client.PickupDirectoryLocation = pickupRoot;
		}
