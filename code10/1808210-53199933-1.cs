    [assembly: ExportRenderer(typeof(ColoredTableView),typeof(ColoredTableViewRenderer))]
    namespace YOUR_IOS_NAMESPACE
    {
        public class ColoredTableViewRenderer : TableViewRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
            {
                base.OnElementChanged(e);
                if (Control == null)
                    return;
     
                var tableView = Control as UITableView;
                var coloredTableView = Element as ColoredTableView;
                tableView.WeakDelegate = new CustomHeaderTableModelRenderer(coloredTableView);
            }
 
            private class CustomHeaderTableModelRenderer : UnEvenTableViewModelRenderer
            {
                private readonly ColoredTableView _coloredTableView;
                public CustomHeaderTableModelRenderer(TableView model) : base(model)
                {
                    _coloredTableView = model as ColoredTableView;
                }
                public override UIView GetViewForHeader(UITableView tableView, nint section)
                {
                    return new UILabel()
                    {
                        Text = TitleForHeader(tableView, section),
                        TextColor = _coloredTableView.GroupHeaderColor.ToUIColor(),
                        TextAlignment = UITextAlignment.Center
                    };
                }
            }
        }
    } 
