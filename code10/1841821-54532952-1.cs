    [SetUp]
    public void testsetup()
    {
       #initialise driver 
       var category = TestContext.CurrentContext.Test.Properties.Keys;
                if(category.Contains("GoogleTest"))
                {
                       //category1 setup
                }
                else if(category.Contains("FBTest"))
                {
                    //category2 setup
                }
    }
