    static class VMExtensions
    {
        public static IdNameVM HydrateEntityToVM<TModel>(this TModel model)
            where TModel : INameId
        {
            if (model == null) return null;
            return new IdNameVM()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        // update: without generics as Marcus Höglund pointed out
        public static IdNameVM HydrateEntityToVM2(this INameId model)
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
