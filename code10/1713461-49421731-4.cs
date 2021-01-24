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
		
		public async void StartScraping()
		{
            // assuming you are 'awaiting' the results of your scraping method...
			foreach (...)
            {
                await ... scrape a web page ...
                var newItem = new Mainlist()
                {
                    Title = title.ToString().Trim(),
                    Value = value.ToString().Trim()
                };
                // if you instead have multiple items to add at this point,
                // then just create a new List<Mainlist>, add your items to it,
                // then add that list to the ObservableCollection List.
			    Device.BeginInvokeOnMainThread(() => 
			    {
				    List.Add(newItem);
			    });
            }
		}
	}
	
