    public class GridController<TModel> : Web.Controllers.ControllerBase where TModel : new()
        {
            public ActionResult List()
            {
                // Get the model (setup) of the grid defined in the /Models folder.
                JQGridBase gridModel = new TModel() as JQGridBase;
