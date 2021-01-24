    public class TabPaneTagHelper : TagHelper
    {
        private TabContext _tabContext;
        private TabPaneContext _tabPaneContext = new TabPaneContext();
        public string Id
        {
            get => _tabPaneContext.Id;
            set => _tabPaneContext.Id = value;
        }
        public bool IsActive
        {
            get => _tabPaneContext.IsActive;
            set => _tabPaneContext.IsActive = value;
        }
        public string Title
        {
            get => _tabPaneContext.Title;
            set => _tabPaneContext.Title = value;
        }
        public override void Init(TagHelperContext context)
        {
            _tabContext = context.Items.Get<TabContext>();
            _tabContext.Items.Add(_tabPaneContext);
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            _tabPaneContext.Content = await output.GetChildContentAsync();
            output.SuppressOutput();
        }
