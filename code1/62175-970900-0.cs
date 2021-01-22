    set
    {
        if (this.parent != value)
        {
            if (value != null)
            {
                value.Controls.Add(this);
            }
            else
            {
                this.parent.Controls.Remove(this);
            }
        }
    }
