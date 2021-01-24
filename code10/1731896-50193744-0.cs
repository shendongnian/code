    public Thickness Margin {
        get {
            int multiplier = 1;
            if (number == 2 || number == 8) multiplier = 2;
            
            return new Thickness(5, 5, 5 * multiplier, 5);
        }
    }
