        class MyItem
        {
            public double Wellness { get; }
        }
        class MyItemViewModel : INotifyPropertyChanged
        {
            public MyItemViewModel(MyItem item, ICultureSpecificDisplay display)
            {
                this.item = item;
                this.display = display;
            }
 
            // TODO: implement INotifyPropertyChanged support
            public string Wellness => display.GetStringWithMeasurementUnits(item.Wellness);
         }
