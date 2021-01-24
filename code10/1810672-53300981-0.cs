    private void UpdateAndSubmitProfile()
    {
        LastNameField.Clear();
        LastNameField.SendKeys("Malik");
        Reporter.LogPassingTestStepToBugLogger("Update Last Name profile field, Last Name => Malik");
        ProfileSubmitButton.Click();
        Reporter.LogPassingTestStepToBugLogger("Click Submit button.");
    }
    public WelcomeScreen UpdateAndSubmitProfileAndGoToWelcomeScreen()
    {
        UpdateAndSubmitProfile();
        return new WelcomeScreen(Driver);
    }
    public LessonPage UpdateAndSubmitProfileAndGoToLessonPage()
    {
        UpdateAndSubmitProfile();
        return new LessonPage(Driver);
    }
