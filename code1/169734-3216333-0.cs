    public class BackingDataClass
    {
        public double LengthAlwaysMetric { get; set; }
    }
    public class BackingDataClassViewModel : INotifyPropertyChanged
    {
        public BackingDataClass Data { get; set; }
        public double Length
        {
            get
            {
                if (Properties.Settings.Default.UseImperialMeasurements == true)
                {
                    return ConvertToImperial(Data.LengthAlwaysMetric);
                }
                else
                {
                    return _lengthAlwaysMetric;
                }
            }
            set
            {
                if (Properties.Settings.Default.UseImperialMeasurements == true)
                {
                    Data.LengthAlwaysMetric = ConvertToMetric(value);
                }
                else
                {
                    Data.LengthAlwaysMetric = value;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("Length"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
