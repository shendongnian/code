    [Test]
    public void ctor_WhenViewIsLoaded_CallsViewRender_WithoutMockingFramework()
    {
        FakeView view = new FakeView();
        Presenter p = new Presenter(fPresenter);
        view.RaiseLoaded();
        Assert.That(view.RenderedText, Is.EqualTo("Hello World"));
    }
