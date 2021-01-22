    public int PK_ButtonNo
    {
        get{ return this.m_pkButtonNo; }
        private set
        {
            if (ButtonNumberChanging != null)
            
            ValueChangingEventArgs vcea = new ValueChangingEventArgs(PK_ButtonNo, value);
            this.ButtonNumberChanging(this, vcea);
            if (!vcea.Cancel)
            {
                PK_ButtonNo = value;
    
                if (ButtonNumberChanged != null)
                this.ButtonNumberChanged(this,EventArgs.Empty);
            }
        }
    }
