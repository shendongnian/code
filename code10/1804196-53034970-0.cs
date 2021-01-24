    public class HyphenPageRouteModelConvention : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            foreach (var selector in model.Selectors.ToList())
            {
                selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template.Replace("_","-");
    
            }
        }
    }
