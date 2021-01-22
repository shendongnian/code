    [Test]
    public void test_MoveRequest_fromView()
    {
        Mockery mockery = new Mockery();
        IPuzzleView view = mockery.NewMock<IPuzzleView>();
        IPuzzleModel model = mockery.NewMock<IPuzzleModel>();
        
        CollectAction collect = new CollectAction(0);
        Expect.Once.On(view).Method("SubscribeMoveRequest").Will(collect);
        Expect.Once.On(model).Method("MoveRequest");
        
        new PuzzlePresenter(model, view);
        Point point = new Point(1, 2);
        PointDelegate del = collect.Parameter as PointDelegate;
        del(point);
        mockery.VerifyAllExpectationsHaveBeenMet();
    }
