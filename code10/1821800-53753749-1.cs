    public class TimeSpanPicker : DateTimePicker
    {
        public TimeSpanPicker()
        { 
            Format = System.Windows.Forms.DateTimePickerFormat.Time;
        }
        public TimeSpan Time
        {
            get
            {
                return this.Value.TimeOfDay;
            }
            set
            {
                this.Value = DateTime.Today.Add(value);
            }
        }
        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            OnNotifyPropertyChanged("Time");
        }
    }
