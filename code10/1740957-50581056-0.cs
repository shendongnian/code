    public class ViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            // Since we are wanting to override the Admin template just look for Admin in the Context, you can also get the controller and view names here.
            if (context.AreaName == AreaNames.Admin)
            {
                //Add the location we want to use instead
                viewLocations = new string[] { $"/Plugins/YourPlugin/Views/Admin/{{0}}.cshtml",
                                              $"/Plugins/YourPlugin/Views/Admin/Shared/{{0}}.cshtml"}.Concat(viewLocations);
            }
            return viewLocations;
        }
    }
