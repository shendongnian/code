    //AbstractViewModel implements INotifyPropertyChanged
    public class MyObject : AbstractViewModel
    {
        private DateTime date = DateTime.UtcNow;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public MyObject()
        {
            Timer t = new Timer();
            t.Interval = 1000; //Update every second
            t.Elapsed += T_Elapsed;
            t.Enabled = true;
        }
        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnPropertyChanged("Date");
        }
    }
