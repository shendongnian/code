    private BindingSource _DataSource;
    [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
    [Editor("System.Windows.Forms.Design.DataSourceListEditor, System.Design", typeof(UITypeEditor))]
    [AttributeProvider(typeof(IListSource))]
    public object DataSource
    {
        get
        {
            return _DataSource;
        }
        set
        {
            //Detach from old DataSource
            if (_DataSource != null)
            {
                _DataSource.ListChanged -= _DataSource_ListChanged;
            }
            _DataSource = value as BindingSource;
            //Attach to new one
            if (_DataSource != null)
            {
                _DataSource.ListChanged += _DataSource_ListChanged;
                //ToDo: look for other (maybe usable) BindingSource events
                //http://msdn.microsoft.com/en-us/library/system.windows.forms.bindingsource_events.aspx
            }
        }
    }
    void _DataSource_ListChanged(object sender, ListChangedEventArgs e)
    {
        //ToDo: Reacht on specific list change
        switch (e.ListChangedType)
        {
            case ListChangedType.ItemAdded:
                break;
            case ListChangedType.ItemChanged:
                break;
            case ListChangedType.ItemDeleted:
                break;
            case ListChangedType.ItemMoved:
                break;
            case ListChangedType.PropertyDescriptorAdded:
                break;
            case ListChangedType.PropertyDescriptorChanged:
                break;
            case ListChangedType.PropertyDescriptorDeleted:
                break;
            case ListChangedType.Reset:
                break;
            default:
                break;
        }
    }
