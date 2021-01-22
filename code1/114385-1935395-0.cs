    private string _Property1;
    [Column(Storage="_Property1", CanBeNull=false)]
    public string Property1 {
        get {
            return this._Property1;
        }
        set {
            if ((this._Property1 != value)) {
               this.OnProperty1Changing(value);
               this.SendPropertyChanging();
               this._Property1 = value;
               this.SendPropertyChanged("Property1");
               this.OnProperty1Changed();
           }
        }
    }
