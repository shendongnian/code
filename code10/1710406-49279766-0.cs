    public class ViewModel: INotifyPropertyChanged
    {
         public EventHandler SomethingHappens;
         // call this to tell something to listener if any (can be view or another view model)
         public OnSomethingHappens() => SomethingHappens?.Invoke(this, EventArgs.Empty);
         ...
    }
