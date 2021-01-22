        public raz()
        {
            this.PropertyChanged += new PropertyChangedEventHandler(raz_PropertyChanged);
        }
        void raz_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "foo")
            {
                 onPropertyChanged(this, "bar");
            }
        }
