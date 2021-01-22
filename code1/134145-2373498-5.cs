	public partial class ListBoxStuff : UserControl
	{
		public ListBoxStuff()
		{
			InitializeComponent();
			DataContext = GetTimedSamples(10, TimeSpan.FromSeconds(5));
		}
		IEnumerable<TimedSample> GetTimedSamples(int count, TimeSpan interval)
		{
			TimedSample sample = null;
			for (int i = 0; i < count; i++)
			{
				sample = new TimedSample()
				{
					Value = String.Format("Item{0}", i),
					Begin = sample != null ? sample.End : DateTime.Now,
					End = (sample != null ? sample.End : DateTime.Now) + interval
				};
				yield return sample;
			}
		}
	}
