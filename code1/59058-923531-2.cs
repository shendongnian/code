     protected virtual void RaisePostDataChangedEvent()
    {
        if (this.AutoPostBack && !this.Page.IsPostBackEventControlRegistered)
        {
            this.Page.AutoPostBackControl = this;
            if (this.CausesValidation)
            {
                this.Page.Validate(this.ValidationGroup);
            }
        }
        this.OnTextChanged(EventArgs.Empty);
    }
