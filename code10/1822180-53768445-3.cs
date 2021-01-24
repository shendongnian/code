    public class ConfigurableContractResolver : DefaultContractResolver
    {
        // This contract resolver taken from the answer to
        // https://stackoverflow.com/questions/46047308/how-to-add-metadata-to-describe-which-properties-are-dates-in-json-net
        // https://stackoverflow.com/a/46083201/3744182
        readonly object contractCreatedPadlock = new object();
        event EventHandler<ContractCreatedEventArgs> contractCreated;
        int contractCount = 0;
        void OnContractCreated(JsonContract contract, Type objectType)
        {
            EventHandler<ContractCreatedEventArgs> created;
            lock (contractCreatedPadlock)
            {
                contractCount++;
                created = contractCreated;
            }
            if (created != null)
            {
                created(this, new ContractCreatedEventArgs(contract, objectType));
            }
        }
        public event EventHandler<ContractCreatedEventArgs> ContractCreated
        {
            add
            {
                lock (contractCreatedPadlock)
                {
                    if (contractCount > 0)
                    {
                        throw new InvalidOperationException("ContractCreated events cannot be added after the first contract is generated.");
                    }
                    contractCreated += value;
                }
            }
            remove
            {
                lock (contractCreatedPadlock)
                {
                    if (contractCount > 0)
                    {
                        throw new InvalidOperationException("ContractCreated events cannot be removed after the first contract is generated.");
                    }
                    contractCreated -= value;
                }
            }
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);
            OnContractCreated(contract, objectType);
            return contract;
        }
    }
    public class ContractCreatedEventArgs : EventArgs
    {
        public JsonContract Contract { get; private set; }
        public Type ObjectType { get; private set; }
        public ContractCreatedEventArgs(JsonContract contract, Type objectType)
        {
            this.Contract = contract;
            this.ObjectType = objectType;
        }
    }
    public static class ConfigurableContractResolverExtensions
    {
        public static ConfigurableContractResolver Configure(this ConfigurableContractResolver resolver, EventHandler<ContractCreatedEventArgs> handler)
        {
            if (resolver == null || handler == null)
                throw new ArgumentNullException();
            resolver.ContractCreated += handler;
            return resolver;
        }
    }
