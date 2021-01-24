    public string Gender { get; set; } = "male";
    private bool ShowMale(object pr)
    {
        if (pr == null) return false;
        Customer c = pr as Customer;
        return c.Gender == this.Gender;
    }
