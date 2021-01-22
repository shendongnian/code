    [AttributeProvider(typeof (IListSource))]
    public object DataSource {
        get { return Editor.DataSource; }
        set { DesignerUtil.SetValue(Component, "DataSource", value); }
    }
