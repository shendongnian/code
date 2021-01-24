    public static IForm<TermFormFlow> BuildForm()
    {
        return new FormBuilder<TermFormFlow>()
                .Message("Bla Bla")
                .Field(new FieldReflector<TermFormFlow>(nameof(DateOfBirth), true)
                            .ReplaceTemplate(new TemplateAttribute(TemplateUsage.NotUnderstood, "I do not understand \"{0}\".", "Try again, I don't get \"{0}\"."))
                            .ReplaceTemplate(new TemplateAttribute(TemplateUsage.DateTimeHelp, "This field should be in the format '01/01/2018'", "Please enter a date or time"))
                            .SetType(typeof(DateTime))
                            .SetFieldDescription(Resources.HolidayResources.Planning_FlowStartDate_Describe)
                            .SetPrompt(new PromptAttribute(Resources.HolidayResources.Planning_FlowStartDate_Prompt)))
                .AddRemainingFields()
                .Build();      
    }
