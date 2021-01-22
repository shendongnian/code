		[ValidateNonEmpty(
			FriendlyNameKey = "CorrectlyLocalized.Description",
			ErrorMessageKey = "CorrectlyLocalized.DescriptionValidateNonEmpty",
			ResourceType = typeof (Messages)
			)]
		public string Description { get; set; }
