    private IPuzzleModel model;
    private IPuzzleView view;
    private PointDelegate pointDelegate;
    private Point point;
    [SetUp]
    public void SetUp()
    {
        model = MockRepository.CreateMock<IPuzzleModel>();
        view = MockRepository.CreateMock<IPuzzleView>();
        presenter = new PuzzlePresenter(model, view);
        // get the delegate passed to the mock when it is called
        // This is one of the more complex things you do with mocks.
        view.Stub(x => x.Subscribe(Arg<PontDelegate>().Is.Anything)
          .WhenCalled(call => pointDelegate = (PointDelegate)call.Arguments[0];);
        point = new Point(1, 2);
    }
    [Test]
    public void test_MoveRequest_fromView()
    {
        // fire the delegate.
        pointDelegate(point);
        // check if the model was called.
        model.AssertWasCalled(x => x.MoveRequest(point));
    }
