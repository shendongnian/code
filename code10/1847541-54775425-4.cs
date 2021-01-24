	public static IForm<MyClass> BuildForm()
	{
		var fieldNames = new[] { nameof(FirstName), nameof(MiddleName), nameof(LastName) };
		var confirmation = new StringBuilder("Is this your selection?");
		var formBuilder = new FormBuilder<MyClass>();
		foreach (var name in fieldNames)
		{
			// Add the field to the form
			formBuilder.Field(name);
			// Add the field to the confirmation prompt unless it's MiddleName
			if (name != nameof(MiddleName))
			{
				confirmation.AppendLine().Append($"* {{&{name}}}: {{{name}}}");
			}
		}
		formBuilder.Confirm(new PromptAttribute(confirmation.ToString()) {
			FieldCase = CaseNormalization.None
		});
		return formBuilder.Build();
	}
