    namespace BB.Common.UI.Adapters
    {
        [AspNetHostingPermission(System.Security.Permissions.SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
        public class DisableViewStateControl : System.Web.UI.Adapters.ControlAdapter
        {
            protected override void OnInit(EventArgs e)
            {
                if (Control.ViewStateMode == ViewStateMode.Inherit)
                    Control.ViewStateMode = ViewStateMode.Disabled;
                base.OnInit(e);
            }
        }
    }
