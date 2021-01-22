    private static void DataSourcePropertyChanged(DependencyObject sender,     
            DependencyPropertyChangedEventArgs args) {
            BarChart _ = sender as BarChart;
            if (args.Property.Equals(BarChart.DataSourceProperty)) {
                System.Collections.IList data = (System.Collections.IList)args.NewValue;
                if (data == null) return;
                foreach (object __ in data) {
                    IChartDataItem item = __ as IChartDataItem;
                    BarChartItem bar = new BarChartItem() {
                        Label = item.Label,
                        Value = item.Value
                    };
                    _._visualCollection.Add(bar);
                    if (_.MaxData < item.Value)
                        _.MaxData = item.Value;
                }
                if (_.Orientation == Orientation.Horizontal)
                    _.Ratio = _.Width / _.MaxData;
            }
        }
