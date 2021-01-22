    [Column(Name="Description", Storage="_Description",
                      DbType="NVarChar(400) NOT NULL", CanBeNull=false)]   
    public string Description
    {
         get { return this._Description; }
         set
         {
             if ((this._Description != value))
             {
                 this.SendPropertyChanging("Description");
                 this._Description = value;
                 this.SendPropertyChanged("Description");
             }
         }
     }
