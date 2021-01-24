    if (Model.ExampleWizardTransaction.ClientDetails.GetStep() == Model.ExampleWizardTransaction.CurrentStep)
    {
        @Html.PartialFor(x => x.ExampleWizardTransaction.ClientDetails, "_WizardStep")
    }
    else if (Model.ExampleWizardTransaction.ClientPreferences.GetStep() == Model.ExampleWizardTransaction.CurrentStep)
    {
        @Html.PartialFor(x => x.ExampleWizardTransaction.ClientPreferences, "_WizardStep")
    }
    else if (Model.ExampleWizardTransaction.ClientQuestions.GetStep() == Model.ExampleWizardTransaction.CurrentStep)
    {
        @Html.PartialFor(x => x.ExampleWizardTransaction.ClientQuestions, "_WizardStep")
    }
