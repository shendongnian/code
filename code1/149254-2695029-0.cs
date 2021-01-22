    namespace MyControls
    {
        public class MyPanel : Panel
        {
            public string Permission { get; set; }
            public string List { get; set; }
            protected override void Render(System.Web.UI.HtmlTextWriter writer)
            {
                if (UserHasPermission()) base.Render(writer);
            }
        }
    }
