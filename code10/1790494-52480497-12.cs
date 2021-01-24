    public int Quantity {
        get => _quantity;
        set {
            if (value < 0)
                throw new ArgumentOutOfRangeException("...");
            _quantity = value;
        }
    }
    
