       public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
    
                //Set child controls here:
                textbox.ForeColor = value;
            }
        }
