	class Presenter
	{
		public ObservableCollection<TVM> ItemsVM { get; }
			= new ObservableCollection<TVM>();
	
		public Loader _loader
			= new Loader(some_well_known_directory_path);
	
		void Populate()
		{
			_loader
				.GetItems()
				.Subscribe(t_item => ItemsVM.Add(new TVM(t_item)));
			}
		}
	}
	
	class Loader
	{
		readonly string _path;
	
		public Loader(string path)
		{
			_path = path;
		}
	
		public IObservable<T> GetItems()
		{
			return
				Observable
					.Defer(() =>
						from fname in Directory.EnumerateFiles(_path).ToObservable()
						from t in Observable.Start(() => T.Load(fname))
						select t);
		}
	}
