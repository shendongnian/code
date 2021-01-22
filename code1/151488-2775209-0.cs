    DataTable table_ = new DataSet1().DataTable1;
    ICollectionView dv_;
    public MainWindow()
    {
        InitializeComponent();
        dv_ = CollectionViewSource.GetDefaultView(table_);
        dv_.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(dv_CollectionChanged);
        lv.ItemsSource = dv_;
    }
    void dv_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add && table_.Rows.Count == 1 )
            dv_.Refresh();
    }
