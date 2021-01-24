        public void ServiceCall<S>(PagedCollectionResultDTO<S> sourceCollection)
        {
            var typeAdapter = new TypeAdapter();
            if (typeof(S) == typeof(ExampleDTO))
            {
                var targetCollection = typeAdapter.Adapt<ExampleDTO, ExampleModel>(sourceCollection as PagedCollectionResultDTO<ExampleDTO>);
            }
            else if(typeof(S) == typeof(ExampleDTO2))
            {
                var targetCollection = typeAdapter.Adapt<ExampleDTO2, ExampleModel2>(sourceCollection as PagedCollectionResultDTO<ExampleDTO2>);
            }
        }
