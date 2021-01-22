    private string _traceOutput;
    private readonly MyTraceListener _trace = new MyTraceListener();
    // Constructor
    public MainViewModel() {
        // ...your viewmodel initialization code.
        // Add event handler in order to expose logs to MainViewModel.TraceOutput property.
        WeakEventManager<INotifyPropertyChanged, PropertyChangedEventArgs>.AddHandler(_trace, "PropertyChanged", traceOnPropertyChanged);
        Trace.Listeners.Add(_trace);
    }
    private void traceOnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Trace")
            TraceOutput = _trace.Trace;
    }
    
    public string TraceOutput
    {
        get { return _traceOutput; }
        set {
            _traceOutput = value;
            RaisePropertyChanged(); // This method is from Mvvm-light.
        }
    }
