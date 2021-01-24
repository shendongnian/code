    public override void PostExecute()
    {
        base.PostExecute();
        VariableDispenser variableDispenser = (VariableDispenser)this.VariableDispenser;
        variableDispenser.LockForWrite("User::NextPageLink");
        this.ReadWriteVariables["User::NextPageLink"].Value = nextpagelink;
              
     }
    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        nextpagelink = Row.href;
    }
