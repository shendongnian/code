	// We want our HasMiddleName field to be treated as the "Middle Name" field for navigation purposes
	[Describe("Middle Name"), Prompt("Does the dependent have a middle name?"), Template(TemplateUsage.NavigationFormat, "{&}({MiddleName})", FieldCase = CaseNormalization.None)]
	public bool HasMiddleName { get; set; }
	// I'm showing you how to use the "Unspecified" template but for some reason it doesn't work in the navigation step.
	// Also, be careful about giving two fields the same description. It works in this case because of the tricks we're using.
	[Optional, Describe("Middle Name"), Prompt("Please enter middle name {||}"), Template(TemplateUsage.NoPreference, "None"), Template(TemplateUsage.Unspecified, "None")]
	public string MiddleName { get; set; }
	[Template(TemplateUsage.NavigationFormat, "{&}({:d})", FieldCase = CaseNormalization.None)]
	public DateTime DateOfBirth { get; set; }
	public static IForm<MyClass> BuildForm()
	{
		var builder = new FormBuilder<MyClass>()
			.Field(new FieldReflector<MyClass>(nameof(HasMiddleName)).SetNext((value, state) =>
			{
				// This NextDelegate will execute after the user enters a value for HasMiddleName
				bool didTheySayYes = (bool)value;
				// If MiddleName is inactive it will be skipped over
				state._isMiddleNameActive = didTheySayYes;
				if (didTheySayYes)
				{
					// We need to explicitly navigate to the MiddleName field
					// or else it will go back to the confirmation step
					// if a middle name had already been entered
					return new NextStep(new[] { nameof(MiddleName) });
				}
				else
				{
					// We want to clear the middle name in case one had been entered before
					state.MiddleName = null;
					// This will go to either the DateOfBirth field or the confirmation step
					// since the MiddleName field will be inactive in this case
					return new NextStep();
				}
			}))
			.Field(new FieldReflector<MyClass>(nameof(MiddleName)).SetActive(state => state._isMiddleNameActive))
			.Field(new FieldReflector<MyClass>(nameof(DateOfBirth)))
			.Confirm(async state =>
			{
				// We're making sure MiddleName is inactive at the confirmation step
				// so it won't be visible in the navigation step,
				// but since we're not changing the MiddleName field
				// it can still be retrieved from the form's result
				state._isMiddleNameActive = false;
				return new PromptAttribute("Ok. Is this correct? {||}");
			});
		return builder.Build();
	}
	// This private field isn't included in the form
	private bool _isMiddleNameActive;
