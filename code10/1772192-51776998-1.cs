    public class PEProcessor : IPEProcessor {
        public PEProcessor(IService service) {
            _proxy = service;
            _emUpdate = new EMUpdate(service);
        }    
    
        public async Task CreateAddress(string modelName, string version, string name, MType mType, Address address, EMRequest request) {
            var response = await _proxy.EMCreateAsync(request); // should return object of type (awaitable) System.Threading.Tasks.Task<EMCResponse>
            address.Id = Convert.ToInt32(response.CM[0].Code);
        }
    }
