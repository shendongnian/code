    private void UpdateValue()
            {
                this.Value = this.Acres * this.YieldPerAcre * this.UnitPrice;
            }      
           public double Acres
            {
                get { return _cropProductionRecord.Acres; }
                set
                {
                    _cropProductionRecord.Acres = value;
                    OnPropertyChanged("Acres");
                    UpdateValue();
                }
            }
            public double YieldPerAcre
            {
                get { return _cropProductionRecord.YieldPerAcre; }
                set
                {
                    _cropProductionRecord.YieldPerAcre = value;
                    OnPropertyChanged("YieldPerAcre");
                    UpdateValue();
                }
            }
      
            public double UnitPrice
            {
                get { return _cropProductionRecord.UnitPrice; }
                set
                {
                    _cropProductionRecord.UnitPrice = value;
                    OnPropertyChanged("UnitPrice");
                    UpdateValue();
                }
            }
            public double Value
            {
                get { return _cropProductionRecord.Value; }
                set
                {
                    _cropProductionRecord.Value = value;
                    OnPropertyChanged("Value");
                }
            }
