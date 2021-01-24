    namespace so53567553
    {
        using Models;
    
        class Program
        {
            static async Task Main(string[] args)
            {
                var service = new TestStationService();
                var vm = new ViewModels.StationEditViewModel(service);
                vm.PropertyChanged += (s, e) => Console.WriteLine($"PropertyChanged '{e.PropertyName}'");
    
                // we will work on a new Station
                Console.WriteLine("* Create Station");
    
                await vm.InitializeAsync(null);
    
                vm.Name = "New Station";
                vm.SaveCommand.Execute(null);
    
                // we will work on an existing Station
                Console.WriteLine("* Edit Station");
    
                await vm.InitializeAsync(new Station("Paddington"));
                vm.Name = "London";
                vm.SaveCommand.Execute(null);
            }
        }
    
        class TestStationService : Services.IStationService
        {
            public Task CreateAsync(Station model)
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                Console.WriteLine($"Create Station '{model.Name}'");
                return Task.CompletedTask;
            }
    
            public Task UpdateAsync(Station oldModel, Station newModel)
            {
                if (oldModel == null)
                {
                    throw new ArgumentNullException(nameof(oldModel));
                }
    
                if (newModel == null)
                {
                    throw new ArgumentNullException(nameof(newModel));
                }
    
                Console.WriteLine($"Update Station from '{oldModel.Name}' to '{newModel.Name}'");
                return Task.CompletedTask;
            }
        }
    }
