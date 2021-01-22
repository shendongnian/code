    protected virtual void RaisePostBackEvent(string eventArgument)
    {
        base.ValidateEvent(this.UniqueID, eventArgument);
        if (this.CausesValidation)
        {
            this.Page.Validate(this.ValidationGroup);
        }
        this.OnClick(EventArgs.Empty);
        this.OnCommand(new CommandEventArgs(this.CommandName, this.CommandArgument));
    }
    
