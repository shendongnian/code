    [TestFixture]
    public class GeneralFixture
    {
         [Test]
         public void VerifyAppDomainHasConfigurationSettings()
         {
              string value = ConfigurationManager.AppSettings["TestValue"];
              Assert.IsFalse(String.IsNullOrEmpty(value), "No App.Config found.");
         }
    }
