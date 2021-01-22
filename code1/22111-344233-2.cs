    public class MyObject
    {
         public void Configure(MyConfigurationObject config)
         {
              _enabled = config.Enabled;
         }
         public string Foo()
         {
             if (_enabled)
             {
                 return "foo!";
             }
             return String.Empty;
         }
         private bool _enabled;
    }
    [TestFixture]
    public class MyObjectTestFixture
    {
         [Test]
         public void CanInitializeWithProperConfig()
         {
             MyConfigurationObject config = new MyConfigurationObject();
             config.Enabled = true;
             MyObject myObj = new MyObject();
             myObj.Configure(config);
             Assert.AreEqual("foo!", myObj.Foo());
         }
    }
