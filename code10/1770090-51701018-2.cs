       private object _ProductSelected;
          public object ProductSelected
        {
            get { return _ProductSelected; }
            set
            {
                _ProductSelected = value;
                 ProductSelected_SelectedIndex.Execute(value);
                 OnPropertyChanged("ProductSelected"); //in case you are using MVVM Light
            }
        }
     private Command ProductSelected_SelectedIndex
        {
            get
            {
                return new Command((e) =>
                {
              }}}
     private object _CitySelectedFromList;
        public object CitySelectedFromList
        {
            get { return _CitySelectedFromList; }
            set
            {
                _CitySelectedFromList = value;
                var cityid = _CitySelectedFromList as CityMasterModel;
                tempcityids = Convert.ToInt32(cityid.Id);
             
            }
        }
