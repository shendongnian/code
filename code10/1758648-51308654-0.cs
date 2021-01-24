    using TechTalk.SpecFlow;
    namespace SampleAutomationTests.StepDefinitions
    {
    [Binding]
    public sealed class AuthenticationFeatureSteps
    {
        HomePage page = new HomePage(Hooks.Driver);
        AuthenticationPage authpage = new AuthernticationPage(Hooks.Driver);
        [Given(@"I opened the home page")]
        public void GivenIOpenedTheHomePage()
        {
            page.GoTo();
        }
        [Given(@"I navigated to Basic Auth link")]
        public void GivenINavigatedToBasicAuthLink()
        {
            page.GoToAuthenticationPage();
        }
    }
    }
