    public class MyTestClass {
        public class FakePresenter : IView {
            public event Action Loaded = delegate { };
            public void Render(string text) {
                RenderedText = text;
            }
            public string RenderedText { get; private set; }
            public void Load() {
                Loaded();
            }
        }
        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender_WithoutMockingFramework() {
            //Arrange
            var fake = new FakePresenter();
            var subject = new Presenter(fake);
            var expected = "Hello Word";
            //Act
            fake.Load();
            var actual = fake.RenderedText;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
