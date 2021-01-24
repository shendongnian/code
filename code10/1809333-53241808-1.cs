    static class VMExtensions
    {
        static IdNameVM HydrateEntityToVM<TModel>(this TModel model)
            where TModel : INameId
        {
            if (model == null) return null;
            return new IdNameVM()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        static void Test()
        {
            var model = new ProjectValue();
            var model2 = new AnotherModel();
            var viewModel = model2.HydrateEntityToVM();
            var viewModel2 = model2.HydrateEntityToVM();
        }
    }
