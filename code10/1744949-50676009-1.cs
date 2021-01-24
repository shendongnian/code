    [Binding]
    public class MyFantasticFeatureBindings
    {
        [Given("I have a (.*)")]
        public void ConfigureTest(string path)
        {
            // setup any configuration here - actually it can be the expected value, too
            ScenarioContext.Current.Set(path, nameof(path));
        }
        [When("I perform a test")]
        public void DoTest()
        {
            // obtain configuration, do the test and store the results and possible errors
            var path = ScenarioContext.Current.Get<string>("path");
            var result = PerformTest(path); // TODO - you have to implement this
            ScenarioContext.Current.Set(result, nameof(result)); 
        }
        [Then("the expected result is (.*)")]
        public void Assertions(string expectedResult)
        {
            var actualResult = ScenarioContext.Current.Get<string>("result");
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
