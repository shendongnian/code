    [TestFixture]
    public class PluralizationServiceTests
    {
        [Test]
        public void Test01()
        {
            var service = PluralizationService.CreateService(CultureInfo.CurrentCulture);
            Assert.AreEqual("tigers", service.Pluralize("tiger"));
            Assert.AreEqual("processes", service.Pluralize("process"));
            Assert.AreEqual("fungi", service.Pluralize("fungus"));
            Assert.AreNotEqual("syllabi", service.Pluralize("syllabus")); // wrong pluralization
        }
    }
