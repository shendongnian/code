        private class InternalOnlyCtorContractResolver : IContractResolver
        {
            private readonly IContractResolver _base;
            
            public InternalOnlyCtorContractResolver(IContractResolver _base)
            {
                this._base = _base;
            }
            
            public JsonContract ResolveContract(Type type)
            {
                var contract = _base.ResolveContract(type);
                var objectContract = contract as JsonObjectContract;
                if (objectContract != null)
                {
                    var creatorParameters = new HashSet<string>(objectContract.CreatorParameters.Select(p => p.PropertyName));
                    var irrelevantProperties = objectContract.Properties
                        .Where(p => !creatorParameters.Contains(p.PropertyName))
                        .ToArray();
                    foreach (var irrelevantProperty in irrelevantProperties)
                    {
                        objectContract.Properties.Remove(irrelevantProperty);
                    }
                    //TODO Can be optimized better
                }
                return contract;
            }
        }
