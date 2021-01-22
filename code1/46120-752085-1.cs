    private IPuzzleModel model;
    private IPuzzleView view;
    private PointDelegate pointDelegate;
    private Point point;
    [SetUp]
    public void SetUp()
    {
        model = MockRepository.CreateMock<IPuzzleModel>();
        view = MockRepository.CreateMock<IPuzzleView>();
        // get the delegate passed to the mock when it is called
        // This is one of the more complex things you do with mocks.
        view.Stub(x => x.Subscribe(Arg<PontDelegate>().Is.Anything)
          .WhenCalled(call => pointDelegate = (PointDelegate)call.Arguments[0];);
        point = new Point(1, 2);
    }
    [Test]
    public void test_MoveRequest_fromView()
    {
        PuzzlePresenter presenter = new PuzzlePresenter(model, view);
        // make sure the Delegate method was called and the delegate
        // is available
        Assert.IsNotNull(pointDelegate);
        // fire the delegate.
        pointDelegate(point);
        // check if the model was called.
        model.AssertWasCalled(x => x.MoveRequest(point));
    }
