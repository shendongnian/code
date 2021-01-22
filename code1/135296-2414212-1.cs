    public ColumnInputChart(ChartViewModel vm, SimpleCallback cb)
    {
        InitializeComponent();
    
        this.vm = vm;
        this.cbStartScroll = cb;
        this.Chart.DataContext = vm;
