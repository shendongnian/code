       set
        {
            this.reportConfiguration.PrintPackingCode = value;
            IsGroupEnabled = !value; // reverse of packing to enable/disable.
            this.OnPropertyChanged("PrintPackingCode");
        }
