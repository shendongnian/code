    public class Test : System.Web.UI.WebControls.HierarchicalDataBoundControl
    {
        protected override void PerformDataBinding()
        {
            base.PerformDataBinding();
            System.Web.UI.HierarchicalDataSourceView view = base.GetData("View Path");
        }
    }
