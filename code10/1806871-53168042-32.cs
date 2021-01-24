    class Result : INotifyPropertyChanged
    {
        private double total;
    
        public Result(Brand brandRef)
        {         
            this.Brand = brandRef;
            brand.OnBrandSelect += (s, args) => 
                { 
                   /* Call calculation method (TotalAmount = TotalArea * 
                      args -- args is rate) and set the result */
                   Total = /*(TotalAmount = TotalArea * 
                      args -- args is rate)*/;
                }
        }
        public double Total   
        {
            get { return total; }
            set
            {
                total = value;
                NotifyPropertyChanged();
            }
        }
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
