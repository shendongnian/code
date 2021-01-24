    public static bool IsValid(string price) {
        var result = Decimal.TryParse(price, out decimal d);
        if (result && d != 0) {
            return true;
        }
        
        return false;
    }
    
