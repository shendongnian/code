    public class RoomObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
    
        }
        public RoomObject(Item dataSourece)
        {
            this.dataSourece = dataSourece;
            ModifyAvilable();
        }
     
        private void ModifyAvilable()
        {
            this.Name = dataSourece.room.name;
            DispatcherTimer startTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(10) };
            startTimer.Tick += (s, e) =>
            {
                this.IsAvailable = true;
                DispatcherTimer endTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
                endTimer.Tick += (o, p) =>
                {
                    this.IsAvailable = false;
                    endTimer.Stop();
                };
                endTimer.Start();
                startTimer.Stop();
            };
            startTimer.Start();
        }
  
    
        public Item dataSourece;
    
        private bool _isAvailable;
        public bool IsAvailable
        {
            get
            {
                return _isAvailable;
            }
            set
            {
                _isAvailable = value;
                OnPropertyChanged();
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    
    }
