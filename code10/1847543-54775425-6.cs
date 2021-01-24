    [Optional]
    public string MiddleName { get; set; }
	public static IForm<MyClass> BuildForm()
	{
		NextDelegate<MyClass> next = (value, state) =>
		{
			// Make sure MiddleName is active during most steps
			state._isMiddleNameActive = true;
			return new NextStep();
		};
		var formBuilder = new FormBuilder<MyClass>()
			.Field(new FieldReflector<MyClass>(nameof(FirstName)).SetNext(next))
			.Field(new FieldReflector<MyClass>(nameof(MiddleName)).SetNext(next)
				.SetActive(state => state._isMiddleNameActive))
			.Field(new FieldReflector<MyClass>(nameof(LastName)).SetNext(next))
			;
		formBuilder.Confirm(async state =>
			{
				// Make sure MiddleName is inactive during the confirmation step
				state._isMiddleNameActive = false;
				// Return the default confirmation prompt
				return new PromptAttribute(
					formBuilder.Configuration.Template(TemplateUsage.Confirmation));
			});
		return formBuilder.Build();
	}
	// This private field isn't included in the form but is accessible via the form's state
	private bool _isMiddleNameActive;
