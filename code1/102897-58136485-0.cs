csharp
    public static class ButtonExtensions
    {
        public static IDisposable Bind(this ButtonBase invoker, ICommand command)
        {
            void Click(object sender, EventArgs args) => command.Execute(null);
            void CanExecuteChanged(object sender, EventArgs args) => invoker.Enabled = command.CanExecute(null);
            invoker.Enabled = command.CanExecute(null);
            
            invoker.Click += Click;
            command.CanExecuteChanged += CanExecuteChanged;
            return Disposable.Create(() =>
            {
                invoker.Enabled = false;
                invoker.Click -= Click;
                command.CanExecuteChanged -= CanExecuteChanged;
            });
        }
    }
You can use it like this: 
csharp
private List<IDisposable> Disposables { get; } = new List<IDisposable>();
private ICommand MyCommand { get; }
public MyControl()
{
    MyCommand = DelegateCommand.Create(() => ...);
    Disposables.Add(myButton.Bind(MyCommand));
}
~MyControl()
{
    foreach(var disposable in Disposables)
    {
        disposable?.Dispose();
    }
}
However, one might prefer to use ReactiveUI, which has native support for this: 
https://stackoverflow.com/questions/24768640/reactiveui-6-0-and-winforms-binding 
