    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class SomeListControl : UserControl
...
    [Category("Data")]
    [Description("Indicates the source of data for the control.")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [AttributeProvider(typeof(IListSource))]
    public object DataSource
    {
        get { return _ultraGrid.DataSource; }
        set { _ultraGrid.DataSource = value; }
    }
    [Category("Data")]
    [Description("Indicates a sub-list of the data source to show in the control.")]
    [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", typeof(UITypeEditor))]    public string DataMember
    {
        get
        {
            return _ultraGrid.DataMember;
        }
        set
        {
            _ultraGrid.DataMember = value;
        }
    }
