    // ViewModel constructor
    GetResult = ReactiveCommand.CreateFromTask(async () => _model.GetResultAsync()); // notice that method is async
    // there is also overload with CancelationToken
    
    _result = GetResult.Retry(3).ToProperty(this, x => x.Result); // we can retry few times and we get change notification
    
    GetResult.Subscribe(result =>{
     // do something as soon as the result is loaded
    });   
    GetResult.ThrownExceptions.Subscribe( errorHandler);
    
    // ViewModel properties
    private ObservableAsProperetyHelper<ResultType> _result;
    
    public ResultType Result => _result.Value;
    
    // view constructor
    
    this.WhenActivated(d =>{ // d is CompositeDisposable for cleanup
      ViewModel.GetResult.Execute().Subscribe().DisposeWith(d); // cancel command if the view is deactivated before it's finished
    });
