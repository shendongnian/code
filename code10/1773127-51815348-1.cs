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
		private string _Text = null;
		public string Text
		{
			get
			{
				if (this._Text != null)
					return this._Text;
				Task.Run(async () => {
					Debug.WriteLine($"Fetching value # {Value}");
					await Task.Delay(1000); // simulate delay in fetching the value
					this.Text = $"Item # {Value}";
				});
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
