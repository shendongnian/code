    using System.Web.UI;
    using System.Web.UI.Adapters;
    
    namespace Playground.Web.UI.Adapters
    {
        public class PageAdapter: System.Web.UI.Adapters.PageAdapter
        {
            protected override void OnLoad(EventArgs e)
            {
                ViewStateMode = ViewStateMode.Disabled;
                base.OnLoad(e);
            }
        }
    }
