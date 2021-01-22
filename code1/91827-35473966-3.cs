    public RequiredSecureStringAttribute()
        :base("Field is required")
    {            
    }
    public override bool IsValid(object value)
    {
        return (value as SecureString)?.Length > 0;
    }
}
