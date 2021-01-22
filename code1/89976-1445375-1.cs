/* PageController.cs */
public event EventHandler SomeEvent;
protected virtual void OnSomeEvent(EventArgs e)
{
    Debug.Assert(null != e);
    var handler = this.SomeEvent;
    if (null != handler)
        handler(this, e);
}
public void FireSomeEvent()
{
   this.OnSomeEvent(EventArgs.Empty);
}
/* ControlPresenter */
public ControlPresenter(IControlView view)
    : base()
{
    view.EventFired += (sender, e) =>
    {
        var controller = HttpContext.Current.Items["Controller"] as PageController;
        controller.FireSomeEvent();
    };
}
/* MasterPresenter */
public MasterPresenter (IMasterView view)
    : base()
{
    var controller = HttpContext.Current.Items["Controller"] as PageController;
    controller.SomeEvent += (sender, e) => view.MyFunction();
}
