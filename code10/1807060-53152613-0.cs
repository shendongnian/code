    public class SomeActionModelConvention : IActionModelConvention
    {
        public void Apply(ActionModel model)
        {
            model.Filters.Add(new AuthorizeFilter(model.ActionName));
        }
    }
