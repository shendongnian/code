    public Screen UpdateAndSubmitProfile()
    {
        LastNameField.Clear();
        LastNameField.SendKeys("Malik");
        Reporter.LogPassingTestStepToBugLogger("Update Last Name profile field, Last Name => Malik");
        ProfileSubmitButton.Click();
        Reporter.LogPassingTestStepToBugLogger("Click Submit button.");
        if(...)
            return new WelcomeScreen(Driver);
        else
            return new LessonPage(Driver);
    }
