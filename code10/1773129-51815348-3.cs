	public class MainViewModel : ViewModelBase
	{
		public Item[] Items { get; }
		public MainViewModel()
		{
			this.Items = Enumerable
				.Range(1, 1000)
				.Select(i => new Item { Value = i })
				.ToArray();
		}
	}
	public class Item : ViewModelBase
	{
		public int Value { get; set; }
		private string _Text;
		public string Text
		{
			get
			{
				// if already loaded then return what we got
				if (!String.IsNullOrEmpty(this._Text))
					return this._Text;
				// otherwise load the value in a task (this will raise property changed event) 
				Task.Run(async () => {
					Debug.WriteLine($"Fetching value # {Value}");
					await Task.Delay(1000); // simulate delay in fetching the value
					this.Text = $"Item # {Value}";
				});
				// return default string for now
				return "Loading...";
			}
			set
			{
				if (this._Text != value)
				{
					this._Text = value;
					RaisePropertyChanged(() => this.Text);
				}
			}
		}
	}
