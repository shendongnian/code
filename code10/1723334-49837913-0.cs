    namespace specflow
    {
        [Binding]
        public class Class1
        {
            private static string id;
    
            [Given(@"I have a new user")]
            public void GivenIHaveANewUser()
            {
                id = "5";
            }
    
            [Given(@"I have the same user")]
            public void GivenIHaveTheSameUser()
            {
                Assert.That(id, Is.EqualTo("5"));
            }
        }
    }
    Feature: SpecFlowFeature1
    
    Scenario: new user
    	Given I have a new user
    
    Scenario: same user
    	Given I have the same user
