    public static class EntityModelProvider
    {
        private static readonly Dictionary<OperationContext, MyEntityModel> _entityModels = new Dictionary<OperationContext, MyEntityModel>();
        public static MyEntityModel GetEntityModel()
        {
            if (OperationContext.Current == null)
                throw new Exception("OperationContext is missing");
            lock (_entityModels)
            {
                if (!_entityModels.ContainsKey(OperationContext.Current))
                {
                    _entityModels[OperationContext.Current] = new MyEntityModel();
                    OperationContext.Current.OperationCompleted += delegate
                    {
                        lock (_entityModels)
                        {
                            _entityModels[OperationContext.Current].Dispose();
                            _entityModels.Remove(OperationContext.Current);
                        }
                    };
                }
                return _entityModels[OperationContext.Current];
            }
        }
