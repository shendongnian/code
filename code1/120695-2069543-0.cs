     public decimal SmallerValue
        {
            get
            {
                return smallerValue;
            }
            set
            {
                bool fireForBigger = smallerValue > biggerValue && smallerValue < value;
                smallerValue = value;
                OnPropertyChanged("SmallerValue");
                if (fireForBigger)
                {
                    OnPropertyChanged("BiggerValue");
                }
            }
        }
