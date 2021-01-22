        [DefaultValue(double.MaxValue)]
        public double Vertical 
        { 
            get { return optional.Get<double>("Vertical") ?? double.MaxValue; }
            set { optional = optional.Set<double>("Vertical", value); } 
        }
            
        public void ClearVertical()
        {
            optional = optional.ClearValue<double>("Vertical");   
        }
