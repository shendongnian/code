    public override TypeConverter Converter
    {
        get {
            if (this.PropertyType.Equals(typeof(States)) ) {
                return new StatesList(); ; 
            }
            return base.Converter;
        }
    }
