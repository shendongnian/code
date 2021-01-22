    internal bool HasDigit(string password) { .. }
    internal bool HasNonAlpha(string password) { .. }
    bool IsStrong(string password) {  
       return HasDigit(password) && HasNonAlpha(password);
    }   
