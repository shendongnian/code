    public SmartForm() {}
    public SmartForm(string loadCode)
    {
        _loadCode = loadCode;
        SmartForms smartForms = new SmartForms(_loadCode);
        //this = smartForms.Collection[0]; //PSEUDO-CODE
    }
