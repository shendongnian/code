        public Series[] SeriesCollections { get; set; }
        public OptChartSeriesEditor(Series[] _seriesCollections)
        {
           InitializeComponent();
           btnOK.Click += (source, e) =>
           {
               //do some saving or other logic required after ok
               this.DialogResult = DialogResult.OK;
               this.Close();
           };
           btnCancel.Click += (source, e) => 
           {
               this.DialogResult = DialogResult.Cancel;
               this.Close();
           };
        }
