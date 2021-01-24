    public TestDialog(IStatePropertyAccessor<TestState> testStateAccessor, IStatePropertyAccessor<GreetingState> greetingStateAccessor, ILoggerFactory loggerFactory)
            : base(nameof(TestDialog))
        {
            TestStateAccessor = testStateAccessor ?? throw new ArgumentNullException(nameof(testStateAccessor));
            GreetingStateAccessor = greetingStateAccessor ?? throw new ArgumentNullException(nameof(greetingStateAccessor));
            // Add control flow dialogs
            var waterfallSteps = new WaterfallStep[]
            {
                    InitializeStateStepAsync,
                    PromptForAnimalStepAsync,
                    // PromptForCityStepAsync,
                    DisplayTestStateStepAsync,
            };
            AddDialog(new WaterfallDialog(ProfileDialog, waterfallSteps));
            // AddDialog(new TextPrompt(NamePrompt, ValidateName));
            AddDialog(new TextPrompt(AnimalPrompt));
        }
