    [Association(Name="Parent_Child", Storage="_Parent", ThisKey="ParentKey", IsForeignKey=true, DeleteRule="CASCADE")]
    public Parent Parent
    {
        get
        {
            return this._Parent.Entity;
        }
        set
        {
            Parent previousValue = this._Parent.Entity;
            if (((previousValue != value) 
                        || (this._Parent.HasLoadedOrAssignedValue == false)))
            {
                this.SendPropertyChanging();
                if ((previousValue != null))
                {
                    this._Parent.Entity = null;
                    previousValue.Exemptions.Remove(this);
                }
                this._Parent.Entity = value;
                if ((value != null))
                {
                    value.Exemptions.Add(this);
                    this._ParentKey = value.ParentKey;
                }
                else
                {
                    this._ParentKey = default(Nullable<int>);
                }
                this.SendPropertyChanged("Parent");
            }
        }
    }
    	
