public string MyConnectionString
{
    get
    {
        return ((string)(this["MyConnectionString"]));
    }
    set
    {
        this["MyConnectionString"] = value;
    }
}
