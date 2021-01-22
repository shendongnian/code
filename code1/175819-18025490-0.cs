    public static class EntityModelProvider
    {
        private static readonly Dictionary<OperationContext, MyEntityModel> EntityModels = new Dictionary<OperationContext, MyEntityModel>();
        public static MyEntityModel GetEntityModel()
        {
            if (OperationContext.Current == null)
                throw new Exception("OperationContext is missing");
            lock (EntityModels)
            {
                if (!EntityModels.ContainsKey(OperationContext.Current))
                {
                    EntityModels[OperationContext.Current] = new MyEntityModel();
                    OperationContext.Current.OperationCompleted += delegate
                    {
                        lock (EntityModels)
                        {
                            EntityModels[OperationContext.Current].Dispose();
                            EntityModels.Remove(OperationContext.Current);
                        }
                    };
                }
                return EntityModels[OperationContext.Current];
            }
        }
