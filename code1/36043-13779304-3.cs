		// Arrange - get SitePath from AppDomain.Current.BaseDirectory + ..\
		string pickupPath = Path.Combine(SitePath, "App_Data", "TempSmtp");
		if (!Directory.Exists(pickupPath))
			Directory.CreateDirectory(pickupPath);
		foreach (string file in Directory.GetFiles(pickupPath, "*.eml"))
		{
			File.Delete(file);
		}
		// Act (send some emails)
		// Assert
		Assert.That(Directory.GetFiles(pickupPath, "*.eml").Count(), Is.EqualTo(1));
