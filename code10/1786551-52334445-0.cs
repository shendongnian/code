    public Status status = Status.Enable;
    public string Statusstring
    {
        get
        {
            if (status == Status.Enable)
                return "Enable";
            else
                return "Disable";
        }
    }
