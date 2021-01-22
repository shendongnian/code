    IView view = Stub<IView>();
    Expect( view.ShowText("Hello World") );
    Presenter p = new Presenter( view );
    p.Show();
    Assert.IsTrue( view.MethodsCalled );
