public interface IMyControl
{
    event CancelEventHandler Validating;
}
Apply the interface to your customized controls:
public partial class MyControl : UserControl, IMyControl
{
    ...
}
In your `Form` class, update `SetErrorEvents()` so it cast to `IMyControl` instead:
...
private void SetErrorEvents(object control)
{
    (control as IMyControl).Validating += ValidationEvent;
}
...
