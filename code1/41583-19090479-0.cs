 	public ObservableCollection<TestClass> List
        {
            get { return _List; }
            set {
                if (_List!= value)
                {
                    _List = value;
                    PropertyChanged.Raise(() => List);
                    List.ToList().ForEach(i=> i.PropertyChanged+= (o,e)=>
                    {
                        //PropertyChanged.Raise(() => List);
			raisePropertyChange("List");
			//or what ever you want
                    }
                );
                    
                }
            }
        }
