    [TestFixture]
    public class GridControllerTests
    {
      [TestCase, ForEachAssert]
      public void Get_UsingStaticSettings_Assign()
      {
          var dataRepository = new XmlRepository("test.xml");
          var settingsRepository = new StaticViewSettingsRepository();
          var controller = new GridController(dataRepository, settingsRepository);
          var result = controller.Get("A1");
          AssertOne.From(
            () => Assert.That(this.Result,Is.Not.Null),
            () => Assert.That(this.Result.Data,Is.Not.Null),
            () => Assert.That(this.Result.Data.Count,Is.GreaterThan(0)),
            () => Assert.That(this.Result.State.ViewId,Is.EqualTo(RequestedViewId)),
            () => Assert.That(this.Result.State.CurrentPage, Is.EqualTo(1)));
      }
    }
