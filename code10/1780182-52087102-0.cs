    public class MarketDataViewModel : INotifyPropertyChanged
    { 
    public ObservableCollection<WPFL1Data> MarketData { get; set; }
    ...
    public string FeedStatus
    {
        get { return GetStatus(); }
    }
       ...
       ...
    private void ClientOnOnStateChange(object sender, MarketFeedConnectionState e)
    {
        if (App.IsInvokeRequired)
        {
            App.InvokeMethod(() => ClientOnOnStateChange(sender, e));
            return;
        }
        ...
        // here is where Status Bar's TextBlock should be notified
        // that value has changed.
        //********* The property name should be in quotes **********
        OnPropertyChanged("FeedStatus");
    }
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        var handler = PropertyChanged;
        // problem is here: handler ==  null
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
