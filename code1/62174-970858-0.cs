    /* this code is part of the .NET Framework was decompiled by Reflector and is copyright Microsoft */
        internal virtual Control ParentInternal
        {
            get
            {
                return this.parent;
            }
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
        }
 
