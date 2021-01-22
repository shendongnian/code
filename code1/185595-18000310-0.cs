    public class DataSourceTemplateSelector : DataTemplateSelector
    {
        public DataTemplate IA { get; set; }
        public DataTemplate Dispatcher { get; set; }
        public DataTemplate Sql { get; set; }
        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var ds = item as DataLocationViewModel;
            if (ds == null)
            {
                return base.SelectTemplate(item, container);
            }
            ds.PropertyChanged += (o, args) =>
                {
                    if (args.PropertyName == "SelectedDataSourceType")
                    {
                        //Maybe do this through reflection instead of a cast
                        var cp = (ContentPresenter)container;
                        cp.ContentTemplateSelector = null;
                        cp.ContentTemplateSelector = this;                        
                    }
                };
            switch (ds.SelectedDataSourceType.Value)
            {
                case DataSourceType.Dispatcher:
                    return Dispatcher;
                case DataSourceType.IA:
                    return IA;
                case DataSourceType.Sql:
                    return Sql;
                default:
                    throw new NotImplementedException(ds.SelectedDataSourceType.Value.ToString());
            }
        }
    }
