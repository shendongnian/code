    public class MainViewModel : ReactiveObject
    {
        public ReactiveList<ProcessModel> Processes { get; private set; }
        MonitorService _monitorService;
        public MainViewModel(MonitorService monitorService)
        {
            _monitorService = monitorService;
            Processes = new ReactiveList<ProcessModel>() { ChangeTrackingEnabled = true };
            RxApp.SupportsRangeNotifications = false;
            IObservable<bool> checkboxObservable = this.WhenAnyValue(vm => vm.ShowProcessesIsChecked);
            IObservable<long> intervalObservable = Observable.Interval(TimeSpan.FromMilliseconds(200.0));
            // Start/stop the monitoring.
            checkboxObservable
                // Skip the default unchecked state.
                .Skip(1)
                .ObserveOnDispatcher()
                .Subscribe(
                    isChecked =>
                    {
                        if(isChecked)
                        {
                            Processes.AddRange(monitorService.GetProcesses());
                            monitorService.Start();
                        }
                        else
                        {
                            Processes.Clear();
                            monitorService.Stop();
                        }
                    });
            // Update the memory usage and remove processes that have exited.
            checkboxObservable
                .Select(isChecked => isChecked ? intervalObservable : Observable.Never<long>())
                // Switch disposes of the previous internal observable
                // (either intervalObservable or Never) and "switches" to the new one.
                .Switch()
                .ObserveOnDispatcher()
                .Subscribe(
                    _ =>
                    {
                        // Loop backwards in a normal for-loop to avoid the modification errors.
                        for(int i = Processes.Count - 1; i >= 0; --i)
                        {
                            if(Processes[i].ProcessObject.HasExited)
                            {
                                Processes.RemoveAt(i);
                            }
                            else
                            {
                                Processes[i].UpdateMemory();
                            }
                        }
                    });
            // Add newly started processes to our reactive list.
            monitorService.NewProcessObservable
                .Where(_ => ShowProcessesIsChecked)
                .ObserveOnDispatcher()
                .Subscribe(process => Processes.Add(process));
        }
        private bool _showProcessesIsChecked;
        public bool ShowProcessesIsChecked
        {
            get { return _showProcessesIsChecked; }
            set { this.RaiseAndSetIfChanged(ref _showProcessesIsChecked, value); }
        }
    }
