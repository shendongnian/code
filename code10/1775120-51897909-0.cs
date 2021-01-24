    interface IContractService{}
    
    interface IContractService1: IContractService{}
    interface IContractService2: IContractService{}
    
    class ContractService1 : IContractService1{}
    
    class ContractService2 : IContractService2{}
    
    class ContractServiceFactory {
        private readonly IServiceProvider _serviceProvider;
        public ContractServiceFactory(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;            
        }
        public IContractService GetContractService(string standard) {
            switch(standard) {
                case "standard1" :
                    return _serviceProvider.GetRequiredService<IContractService1>();
                    break;
                case "standard2" :
                    return _serviceProvider.GetRequiredService<IContractService2>();
                    break;
                case .....
            }
        }
    }
