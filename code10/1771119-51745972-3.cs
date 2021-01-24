        public void ServiceCall<S,T>(PagedCollectionResultDTO<S> sourceCollection)
            where T : IExampleModel<S>, new()
        {
            var typeAdapter = new TypeAdapter();
            var targetCollection = typeAdapter.Adapt<S,T>(sourceCollection);
        }
