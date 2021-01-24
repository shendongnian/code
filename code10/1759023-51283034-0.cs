    public class ZlsRouteEditorDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ViewDataTemplate { get;set; }
        public DataTemplate EditDataTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ERouteEditor e)
                return _GetTemplate(e);
            ZlsRouteEditor parent = container.TryFindParent<ZlsRouteEditor>();
            if (parent != null)
                return _GetTemplate(parent.Mode);
            return base.SelectTemplate(item, container);
        }
        private DataTemplate _GetTemplate(ERouteEditor e)
        {
            switch (e)
            {
                case ERouteEditor.View:
                    return ViewDataTemplate;
                case ERouteEditor.Edit:
                    return EditDataTemplate;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
