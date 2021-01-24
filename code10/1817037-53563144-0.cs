    public class NewPosition : ObservableObject
    { 
        private int _id;
        public int ID {
            get => _id;
            set => Set(ref _id, value); 
        }
    
        private PosStatus _status;
        public PosStatus Status {
            get => _status;
            set => Set(ref _status, value);
        }
    
        private Trade _buyTrade;
        public Trade buyTrade { 
            get => _buyTrade;
            set => Set(ref _buyTrade, value);
        }
    
        private Trade _sellTrade;
        public Trade SellTrade { 
            get => _sellTrade;
            set => Set(ref _sellTrade, value);
        }
    }
    
    public class Trade : ObservableObject
    {
        private double _dealPrice;
        public double DealPrice {
            get => _dealPrice;
            set => Set(ref _dealPrice, value);
        }
    }
