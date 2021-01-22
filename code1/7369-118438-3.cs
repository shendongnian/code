        public event EventHandler NameChanged;
        public string Name 
        {
          get
          {
            return this._Name;
          }
          set
          {
            if (value != this._Name)
            {
                this._Name= value;
                if (NameChanged != null) NameChanged(this, EventArgs.Empty);
            }
          }
        }
    
