    public SmartForm(string loadCode)
    {
        _loadCode = loadCode;
        SmartForms smartForms = new SmartForms(_loadCode);
        this.IdCode = smartForms[0].IdCode;
        this.Title = smartForms[0].Title;
    }
