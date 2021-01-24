    namespace ViewModels
    {
        public class StationEditViewModel : Base.ViewModelBase
        {
            public StationEditViewModel(Services.IStationService stationService)
            {
                StationService = stationService ?? throw new ArgumentNullException(nameof(stationService));
            }
    
            protected Services.IStationService StationService { get; }
    
            string _name;
            public string Name { get => _name; set => this.RaiseAndSetIfChanged(ref _name, value); }
    
            public ICommand SaveCommand => ReactiveCommand.CreateFromTask(SaveCommandExecuteAsync);
    
            private async Task SaveCommandExecuteAsync()
            {
                var oldModel = _originalModel;
                var newModel = await SaveToModelAsync();
                if (oldModel == null)
                    await StationService.CreateAsync(newModel);
                else
                    await StationService.UpdateAsync(oldModel, newModel);
                await LoadFromModelAsync(newModel);
            }
            public override Task InitializeAsync(object parameter)
            {
                return LoadFromModelAsync(parameter as Models.Station);
            }
    
            Models.Station _originalModel;
            private Task LoadFromModelAsync(Models.Station model)
            {
                _originalModel = model;
                Name = model?.Name;
                return Task.CompletedTask;
            }
    
            private Task<Models.Station> SaveToModelAsync()
            {
                var model = new Models.Station(Name);
                return Task.FromResult(model);
            }
        }
    }
    
