    public Form1 ()
    {
      InitializeComponent ();
      m_objects = new List<DataObject> {
        new DataObject { Name = "foo", ValueList = new [] { "1", "2", "3", "4" }},
        new DataObject { Name = "bar", ValueList = new [] { "a", "b", "c" }}
      };
      bindingSource1.DataSource = m_objects;
    }
    private IList<DataObject> m_objects;
