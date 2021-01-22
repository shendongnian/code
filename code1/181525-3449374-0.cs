    public bool HasSerialNumber()
    {
        if(this.Properties != null)
            return Properties.Any(p => !string.IsNullOrEmpty(p.SerialNumer));
        return false;
    }
