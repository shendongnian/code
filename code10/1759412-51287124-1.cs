		private Func<IMyViewModel> _myVmCreator;
		
		public ParentViewModel(Func<IMyViewModel> myVmCreator) 
		{
			_friendEditVmCreator = friendEditVmCreator;
		}
		
		public ObservableCollection<IMyViewModel> MyViewModels { get; private set; }
		
		private IMyViewModel CreateMyViewModel()
		{
			var myVm = _myVmCreator();
			MyViewModels.Add(myVm);
			return myVm;
		}
	}
