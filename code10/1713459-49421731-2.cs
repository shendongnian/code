    public class MyViewModel : INotifyPropertyChanged
	{
        // property changed event handler
		public event PropertyChangedEventHandler PropertyChanged;
		
		private ObservableCollection<Mainlist> _list;
		
		public ObservableCollection<Mainlist> List
		{
			get { return _list; }
			set
			{
				_list = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(List)));
			}
		}
		
		public MyViewModel()
		{
			_list = new ObservableCollection<Mainlist>();
		}
		
		public void UpdateList(Mainlist newItem)
		{
			// I'm not sure exactly how you want to update your list,
			// but whenever you have a new item to add, just call UpdateList.
			// Although I'd recommend keeping your web-scraping logic here in the 
			// view model as well.
			Device.BeginInvokeOnMainThread(() => 
			{
				// remember to use the public property "List", not the private variable "_list"
				List.Add(newItem);
			});
		}
	}
	
