    public class SomeControllerModelConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel model)
        {
            foreach (var actionModel in model.Actions)
                actionModel.Filters.Add(new AuthorizeFilter(actionModel.ActionName));
        }
    }
