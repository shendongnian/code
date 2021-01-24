    string nextPageLink = null;
    public override void PostExecute()
    {
        base.PostExecute();
        Variables.NextPageLink = nextPageLink;  
    }
    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        nextPageLink = Row.href;
    }
